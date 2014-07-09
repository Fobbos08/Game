using Game.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WorldGenerators
{
    public class MonsterGenerator : IGenerator<List<Monster>>
    {
        private Random rnd = new Random();
        private LoadEntity le = new LoadEntity();
        private List<MonsterCreator> creators;
        public MonsterGenerator()
        {
            creators = new List<MonsterCreator>();
            creators.Add( new WolfCreator());
            creators.Add( new BirdCreator());
            foreach (var a in le.LoadMonsters())
                creators.Add(a);
        }
        public List<Monster> Generate(World world)
        {
            foreach (var a in world.monsters)
                a.Stop();
            world.monsters.Clear();
            for (int i = 0; i < 10; i++)
            {
                int value = rnd.Next(0, creators.Count);
                Monster m = creators[value].Create(world);
                m.MyPosition = new Position() { X = rnd.Next(50, world.PixelsWidth - 50), Y = rnd.Next(50, world.PixelsHeight - 50)};
                world.monsters.Add(m);
                //world.monsters[world.monsters.Count - 1].EatPlayerEvent += EatPlayer;
            }
            return world.monsters;
        }
    }
}
