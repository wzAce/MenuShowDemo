using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MenuShow
{
    static class MenuOptions
    {
        static private List<MenuBase> RootMenus = new List<MenuBase>();
        static private MenuLeaf currentMenuLeaf;

        static public List<MenuBase> GetStarted(string xmlPath)
        {
            currentMenuLeaf = null;
            RootMenus = GenerateMenu(xmlPath);
            return RootMenus;
        }
        static private List<MenuBase> GenerateMenu(string xmlPath)
        {
            List<MenuBase> MenuList = new List<MenuBase>();
            XmlDocument XDoc = new XmlDocument();
            XDoc.Load(xmlPath);
            var XRoot = XDoc.SelectSingleNode("Root");
            var FirstLevelMenus = XRoot.ChildNodes;
            foreach (XmlNode CNode in FirstLevelMenus)
            {
                if (CNode.HasChildNodes)
                {
                    MenuList.Add(GenerateMenuLeaf(CNode, null));
                }
            }
            return MenuList;
        }

        static private MenuBase GenerateMenuLeaf(XmlNode menuLeaf, MenuBase parentNode)
        {
            if (menuLeaf == null || !menuLeaf.HasChildNodes)
            {
                return null;
            }
            string Name = menuLeaf.SelectSingleNode("Name").InnerText;
            MenuLeaf thisLeaf = new MenuLeaf(parentNode, null, Name);
            List<MenuBase> ChildNodes = new List<MenuBase>();

            foreach (XmlNode node in menuLeaf.ChildNodes)
            {
                if (node.Name == "MenuLeaf" && node.HasChildNodes)
                {
                    ChildNodes.Add(GenerateMenuLeaf(node, thisLeaf));
                }
                else if (node.Name == "MenuNode")
                {
                    ChildNodes.Add(GenerateMenuNode(node, thisLeaf));
                }
            }
            thisLeaf.SetChildLeafs(ChildNodes);
            return thisLeaf;

        }

        static private MenuBase GenerateMenuNode(XmlNode menuNode, MenuBase parentNode)
        {
            if (menuNode == null)
            {
                return null;
            }
            string Name = menuNode.Attributes["Name"].Value;
            return new MenuNode(parentNode, Name);
        }

        static public List<MenuBase> MenuSelected(object menuItem)
        {
            if (menuItem is MenuNode)
            {
                (menuItem as MenuNode).DoMyOwnFuncution();
                return null;
            }
            if (menuItem is MenuLeaf)
            {
                currentMenuLeaf = (menuItem as MenuBase).GetparentLeaf() as MenuLeaf;
                return (menuItem as MenuLeaf).GetChildLeafs();
            }
            return null;
        }

        static public List<MenuBase> MenuUp()
        {
            if (currentMenuLeaf != null)
            {                
                var menuList = (currentMenuLeaf as MenuLeaf).GetChildLeafs();
                currentMenuLeaf = (currentMenuLeaf as MenuLeaf).GetparentLeaf() as MenuLeaf;
                return menuList;                
            }
            else
            {
                return RootMenus;
            }
        }

        static public List<MenuBase> GoToRootMenu()
        {            
            currentMenuLeaf = null;
            return RootMenus;
        }
    }
}
