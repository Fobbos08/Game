using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {
            X = 0;
            Y = 0;
        }

        public void Add(Vector vector, int speed)
        {
            X += vector.X*speed;
            Y += vector.Y*speed;
        }
    }
}
