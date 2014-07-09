using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Bonuses
{
    public class BonusDecorator : Bonus
    {
        public BonusDecorator(World world)
            : base(world)
        {
 
        }

        protected Bonus bonus;

        public void SetBonus(Bonus bonus)
        {
            this.bonus = bonus;
        }

        public override void EatIt(Player player)
        {
            if (bonus != null)
            {
                bonus.EatIt(player);
            }
        }
    }
}
