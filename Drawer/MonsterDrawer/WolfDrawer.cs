using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.MonsterDrawer
{
    public class WolfDrawer : MonsterDrawer
    {
        public WolfDrawer()
        {
            Name = "WOLF";
            b = new SolidBrush(Color.BurlyWood);
        }
    }
}
