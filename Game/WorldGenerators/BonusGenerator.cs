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

        public Bonus Generate(World world)
        {
            List<Position> p = new List<Position>();
            for (int i = 0; i < world.map.GetLength(0); i++)
                for (int j = 0; j < world.map.GetLength(1); j++)
                {
                    if (world.map[i, j].Level <= 1 && world.map[i, j].bonus==null) p.Add(new Position() { X = i, Y = j });
                }

            Bonus b;
            int pos = rnd.Next(0, p.Count);
            b = new StaticBonus(world) { MyPosition = new Position() { X = p[pos].X, Y = p[pos].Y } };
            if (p.Count == 0) return null;
            if (rnd.Next(0, 2) == 0)
            {           
                world.map[p[pos].X, p[pos].Y].bonus = b;
                p.RemoveAt(pos);
            }
            else
            {
                DynamicBonus db = new DynamicBonus(world) { MyPosition = new Position() { X = b.MyPosition.X, Y = b.MyPosition.Y } };
                db.SetBonus(b);
                world.map[p[pos].X, p[pos].Y].bonus = db;
                p.RemoveAt(pos);
            }

            return b;
        }
    }
}
