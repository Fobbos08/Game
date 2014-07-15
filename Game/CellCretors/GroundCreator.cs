using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CellCretors
{
    public class GroundCreator : CellCreator
    {
        public override Cell Create()
        {
            return new Cell() { Name = "GROUND", Level = 0, Speed = 2 };
        }
    }
}
