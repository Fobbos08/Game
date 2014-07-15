using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.BonusDrawer
{
    public class DynamicBonusDrawer : BonusDrawer
    {
        public DynamicBonusDrawer()
        {
            Name = "DYNAMICBONUS";
            b = new SolidBrush(Color.Goldenrod);
        }
    }
}
