using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WorldGenerators
{
    public class MapGenerator :IGenerator<Cell[,]>
    {
        private int width;
        private int height;
        private Random rnd = new Random();
        public MapGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public Cell[,] Generate(World world)
        {
            world.map = new Cell[width, height];///???

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    switch (rnd.Next(0, 3))
                    {
                        case 0: world.map[i, j] = new Cell() { Level = 0, Speed = 2 }; break;
                        case 1: world.map[i, j] = new Cell() { Level = 1, Speed = 1 }; break;
                        case 2: world.map[i, j] = new Cell() { Level = 2, Speed = 4 }; break;
                    }
                }//дописать класс updater отвечающий за исправление ошибок генерации, либо дописать 
                //приватный метод...  дописать волновой алгоритм
            }
            return world.map;
        }
    }
}
