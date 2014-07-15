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
        private LoadEntity le = new LoadEntity();
        private List<CellCretors.CellCreator> cc= new List<CellCretors.CellCreator>();
        public MapGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
            cc.Add(new CellCretors.GroundCreator());
            cc.Add(new CellCretors.GrassCreator());
            cc.Add(new CellCretors.WaterCreator());
            foreach (var a in le.LoadCells())
                cc.Add(a);
        }

        public Cell[,] Generate(World world)
        {
            world.map = new Cell[width, height];///???

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    world.map[i, j] = cc[rnd.Next(0, cc.Count)].Create();
                }//дописать класс updater отвечающий за исправление ошибок генерации, либо дописать 
                //приватный метод...  дописать волновой алгоритм
            }
            return world.map;
        }
    }
}
