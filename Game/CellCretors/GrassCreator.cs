using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CellCretors
{
    public class GrassCreator : CellCreator
    {
        public override Cell Create()
        {
            return new Cell() { Name = "GRASS", Level = 1, Speed = 1 };
        }
    }
}
