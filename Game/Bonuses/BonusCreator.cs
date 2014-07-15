using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Bonuses
{
    public abstract class BonusCreator
    {
        public abstract Bonus Create(World world);
    }
}
