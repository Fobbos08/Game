using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Bonuses
{
    public class StaticBonus : Bonus
    {
        public StaticBonus(World world)
            : base(world)
        { }

        public override void EatIt(Player player)
        {
            //base.EatIt(player);
            world.DeleteThisBonus(this);
        }
    }
}
