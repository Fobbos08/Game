using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Bonuses
{
    public class StaticBonusCreator : BonusCreator
    {
        public override Bonus Create(World world)
        {
            return new StaticBonus(world) { Name = "STATICBONUS"};
        }
    }
}
