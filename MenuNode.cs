using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MenuShow
{
    class MenuNode:MenuLeaf
    {
        public void DoMyOwnFuncution()
        {
            MessageBox.Show(string.Format("执行功能：{0}", Name),"没有下级菜单");
        }

        
        public MenuNode(MenuBase PLeaf,string MyName):base(PLeaf, null, MyName)
        {  }
    }
}
