using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.BonusDrawer
{
    public class StaticBonusDrawer : BonusDrawer
    {
        public StaticBonusDrawer()
        {
            Name = "STATICBONUS";
            b = new SolidBrush(Color.Gold);
        }
    }
}
