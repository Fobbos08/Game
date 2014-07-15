using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawer.BonusDrawer;
using Game;
using System.Drawing;

namespace Drawer
{
    public class BonusesDrawer
    {
        private Dictionary<string, BonusDrawer.BonusDrawer> bonusDrawers = new Dictionary<string, BonusDrawer.BonusDrawer>();
        private LoadEntity le = new LoadEntity();

        public BonusesDrawer()
        {
            BonusDrawer.BonusDrawer bd = new StaticBonusDrawer();
            bonusDrawers.Add(bd.Name, bd);
            bd = new DynamicBonusDrawer();
            bonusDrawers.Add(bd.Name, bd);
            foreach (var value in le.LoadBonuses())
            {
                if (!bonusDrawers.ContainsKey(value.Name))
                bonusDrawers.Add(value.Name, value);
            }
        }
        public void Draw(World world, Graphics graphic, double coefW, double coefH)
        {
            for (int i = 0; i < world.CellWidth; i++)
                for (int j = 0; j < world.CellHeight; j++)
                {
                    if (world.map[i,j].bonus!=null)
                    if (bonusDrawers.ContainsKey(world.map[i,j].bonus.Name))
                        bonusDrawers[world.map[i, j].bonus.Name].Draw(world, graphic, (int)(world.map[i, j].bonus.MyPosition.X * world.SideSizeW * coefW + (world.SideSizeW * coefW) / 2 - world.SideSizeW * coefW / 4), (int)(world.map[i, j].bonus.MyPosition.Y * world.SideSizeH * coefH + (world.SideSizeH * coefH) / 2 - world.SideSizeH * coefH / 4), coefW, coefH);
                }                
        }
    }
}
