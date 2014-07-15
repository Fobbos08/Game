using Game.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Cell
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Speed { get; set; }
        public Bonus bonus { get; set; }
    }
}
