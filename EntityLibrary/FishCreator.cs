using Game;
using Game.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class FishCreator : MonsterCreator
    {
        public override Monster Create(World world)
        {
            //Fish f = (Fish)Activator.CreateInstance(typeof(Fish),world);
               Fish f =  new Fish(world) { Name = "FISH", MyVector = new Vector() { X = 1, Y = 0 } };
                return f;
        }
    }
}
