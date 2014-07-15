using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.CellDrawer
{
    public class WaterDrawer : CellDrawer
    {
        public WaterDrawer()
        {
            Name = "WATER";
            b = new SolidBrush(Color.Blue);
        }

    }
}
