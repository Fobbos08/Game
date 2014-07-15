using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class Drawer
    {
        Bitmap bitmap;
        Graphics graphic;
        MapDrawer mapDrawer = new MapDrawer();
        IDrawer playerDrawer = new PlayerDrawer();
        MonstersDrawer monstersDrawer = new MonstersDrawer();
        BonusesDrawer bonusDrawer = new BonusesDrawer();

        public Drawer(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            graphic = Graphics.FromImage(bitmap);
        }

        public void Draw(World world)
        {
            double coefW = (double)bitmap.Width / (double)world.PixelsWidth;
            double coefH = (double)bitmap.Height / (double)world.PixelsHeight;
            mapDrawer.Draw(world, graphic, coefW, coefH);
            playerDrawer.Draw(world, graphic, world.OnePlayer.MyPosition.X, world.OnePlayer.MyPosition.Y, coefW, coefH);
            monstersDrawer.Draw(world, graphic, coefW, coefH);
            bonusDrawer.Draw(world, graphic, coefW, coefH);
        }

    }
}
