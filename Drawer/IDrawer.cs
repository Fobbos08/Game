using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    interface IDrawer
    {
        void Draw(World world, Graphics graphic, int x, int y, double coefW, double coefH);
    }
}
