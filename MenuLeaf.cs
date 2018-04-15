using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShow
{
    class MenuLeaf: MenuBase
    {
        protected MenuBase ParentLeaf { get; set; }
        protected List<MenuBase> ChildLeafs { get; set; }
        public string Name { get; set; }
        public override MenuBase GetparentLeaf()
        {
            return ParentLeaf;
        }

        public override List<MenuBase> GetChildLeafs()
        {
            return ChildLeafs;
        }

        public string GetName()
        {
            return Name;
        }

        public override bool SetparentLeaf(MenuBase PLeaf)
        {
            if(PLeaf!=null)
            {
                ParentLeaf = PLeaf;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetChildLeafs(List<MenuBase> ChildNodes)
        {
            if (ChildNodes != null && ChildNodes.Count > 0)
            {
                ChildLeafs = ChildNodes;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool SetChildLeafs(List<string> CName ,bool flag)
        {
            ChildLeafs = new List<MenuBase>();
            if (CName!=null&&CName.Count>0)
            {
                if(flag)
                {
                    CName.ForEach(o => ChildLeafs.Add(new MenuLeaf(this, null, o.ToString())));
                }
                else
                {
                    CName.ForEach(o => ChildLeafs.Add(new MenuNode(this, o.ToString())));
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public MenuLeaf(MenuBase PLeaf, List<MenuBase> CLeafs, string MyName):base()
        {
            ParentLeaf = PLeaf;
            Name = MyName;
            ChildLeafs = CLeafs;
        }
    }
}
