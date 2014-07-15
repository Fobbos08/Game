using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Bonuses
{
    public abstract class Bonus
    {
        protected World world;
        public string Name { get; set; }
        public Bonus(World world)
        {
            this.world = world;
        }
        public Position MyPosition { get; set; }
        public abstract void EatIt(Player player);
    }
}
