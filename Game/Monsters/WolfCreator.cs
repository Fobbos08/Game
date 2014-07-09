using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Monsters
{
    public class WolfCreator : MonsterCreator
    {
        public override Monster Create(World world)
        {
            return new Wolf(world) { Name = "WOLF", MyVector = new Vector() { X = 1, Y = 0 } };
        }
    }
}
