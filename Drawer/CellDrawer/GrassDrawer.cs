using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.CellDrawer
{
    public class GrassDrawer : CellDrawer
    {
        public GrassDrawer()
        {
            Name = "GRASS";
            b = new SolidBrush(Color.Green);
        }
    }
}
