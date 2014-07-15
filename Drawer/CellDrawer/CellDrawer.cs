using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.CellDrawer
{
    public class CellDrawer : IDrawer
    {
        public string Name { get; protected set; }
        protected Brush b;
        public virtual void Draw(World world, Graphics graphic, int x, int y, double coefW, double coefH)
        {
            graphic.FillRectangle(b, (int)(x * coefW), (int)(y * coefH), (int)(world.SideSizeW * coefW), (int)(world.SideSizeH * coefH));
        }
    }
}
