using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Bonuses
{
    public class DynamicBonusCreator: BonusCreator
    {
        public override Bonus Create(World world)
        {
            Bonus b = new StaticBonus(world);
            DynamicBonus db = new DynamicBonus(world) { Name = "DYNAMICBONUS" };
            db.SetBonus(b);
            return db;
        }
    }
}
