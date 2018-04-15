using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShow
{
    abstract class MenuBase
    {
        public abstract MenuBase GetparentLeaf();
        public abstract List<MenuBase> GetChildLeafs();
        public abstract bool SetparentLeaf(MenuBase PLeaf);
        public abstract bool SetChildLeafs(List<string> CName,bool flag);
    }
}
