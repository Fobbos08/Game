using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.BonusDrawer
{
    public class BonusDrawer : IDrawer
    {
            public string Name { get; protected set; }
            protected Brush b;
            public virtual void Draw(World world, Graphics graphic, int x, int y, double coefW, double coefH)
            {
            graphic.FillEllipse(b, (int)(x), (int)(y),(int)(world.SideSizeW*coefW / 2), (int)(world.SideSizeH*coefH / 2));
          }
        }
}
