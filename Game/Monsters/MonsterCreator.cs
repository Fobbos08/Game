using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Monsters
{
    public abstract class MonsterCreator : IMonsterCreator
    {
        public abstract Monster Create(World world);
    }
}
