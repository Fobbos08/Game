using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class PlayerDrawer: IDrawer
    {
        protected Brush b;
        public PlayerDrawer()
        {
            b = new SolidBrush(Color.Indigo);
        }

        public virtual void Draw(World world, Graphics graphic, int x, int y, double coefW, double coefH)
        {
            graphic.FillEllipse(b, (int)(x * coefW - world.SideSizeW*coefW / 4), (int)(y*coefH - world.SideSizeH*coefH / 4),(int)(world.SideSizeW*coefW / 2), (int)(world.SideSizeH*coefH / 2));
        }
    }
}
