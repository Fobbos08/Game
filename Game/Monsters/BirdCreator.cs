using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Monsters
{
    public class BirdCreator : MonsterCreator
    {

        public override Monster Create(World world)
        {
            return new Bird(world) { Name = "BIRD", MyVector = new Vector() { X = 1, Y = 0} };
        }
    }
}
