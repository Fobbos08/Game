using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.MonsterDrawer
{
    public class BirdDrawer : MonsterDrawer
    {
        public BirdDrawer()
        {
            Name = "BIRD";
            b = new SolidBrush(Color.Red);
        }
    }
}
