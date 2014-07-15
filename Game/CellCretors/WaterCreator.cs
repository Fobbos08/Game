using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CellCretors
{
    public class WaterCreator : CellCreator
    {
        public override Cell Create()
        {
            return new Cell() { Name = "WATER", Level = 2, Speed = 4 };
        }
    }
}
