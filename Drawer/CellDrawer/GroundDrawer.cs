using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.CellDrawer
{
    public class GroundDrawer : CellDrawer
    {
        public GroundDrawer()
        {
            Name = "GROUND";
            b = new SolidBrush(Color.Gray);
        }
    }
}
