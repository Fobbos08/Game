using Game.Bonuses;
using Game.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WorldGenerators
{
    public class WorldGenerator : IGenerator<World>
    {
        IGenerator<Cell[,]> mapGenerator;
        IGenerator<Bonus> bonusGenerator;
        IGenerator<List<Monster>> monsterGenerator;

        public WorldGenerator(IGenerator<Cell[,]> mapGenerator,
                                IGenerator<Bonus> bonusGenerator,
                                IGenerator<List<Monster>> monsterGenerator)
        {
            this.mapGenerator = mapGenerator;
            this.bonusGenerator = bonusGenerator;
            this.monsterGenerator = monsterGenerator;
        }

        public World Generate(World world)
        {
            world.map = mapGenerator.Generate(world);
            for (int i = 0; i <= 20; i++ )
                bonusGenerator.Generate(world);
            world.monsters = monsterGenerator.Generate(world);
            return world;
        }

    }
}
