using Game.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WorldGenerators
{
    public class BonusGenerator : IGenerator<Bonus>
    {
        private Random rnd = new Random();
        private LoadEntity le = new LoadEntity();
        private List<BonusCreator> bc = new List<BonusCreator>();

        public BonusGenerator()
        {
            bc.Add(new StaticBonusCreator());
            bc.Add(new DynamicBonusCreator());
            foreach (var a in le.LoadBonuses())
                bc.Add(a);
        }

        public Bonus Generate(World world)
        {
            List<Position> p = new List<Position>();
            for (int i = 0; i < world.map.GetLength(0); i++)
                for (int j = 0; j < world.map.GetLength(1); j++)
                {
                    if (world.map[i, j].Level <= 1 && world.map[i, j].bonus==null) p.Add(new Position() { X = i, Y = j });
                }
            int pos = rnd.Next(0, p.Count-1);
            if (p.Count == 0) return null;
            int numberCreator = rnd.Next(0, bc.Count);
            world.map[p[pos].X, p[pos].Y].bonus = bc[numberCreator].Create(world);
            world.map[p[pos].X, p[pos].Y].bonus.MyPosition = new Position() { X = p[pos].X, Y = p[pos].Y };
            p.RemoveAt(pos);
            return world.map[p[pos].X, p[pos].Y].bonus;
        }
    }
}
