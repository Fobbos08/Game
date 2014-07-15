using Game;
using Game.Monsters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class MonstersDrawer
    {
        private Dictionary<string, MonsterDrawer.MonsterDrawer> monstersDrawers = new Dictionary<string, MonsterDrawer.MonsterDrawer>();
        private LoadEntity le = new LoadEntity();

        public MonstersDrawer()
        {
            MonsterDrawer.MonsterDrawer md = new MonsterDrawer.WolfDrawer();
            monstersDrawers.Add(md.Name, md);
            md = new MonsterDrawer.BirdDrawer();
            monstersDrawers.Add(md.Name, md);
            foreach (var value in le.LoadMonsters())
            {
                if (!monstersDrawers.ContainsKey(value.Name))
                monstersDrawers.Add(value.Name, value);
            }

        }
        public void Draw(World world, Graphics graphic, double coefW, double coefH)
        {
            foreach(var monster in world.monsters)
                {
                    if (monstersDrawers.ContainsKey(monster.Name))
                        monstersDrawers[monster.Name].Draw(world, graphic, monster.MyPosition.X, monster.MyPosition.Y, coefW, coefH);
                }
        }
    }
}
