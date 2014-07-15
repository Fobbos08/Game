using Drawer.MonsterDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawersLibrary
{
    public class FishDrawer : MonsterDrawer
    {
        public FishDrawer()
        {
            Name = "FISH";
            b = new SolidBrush(Color.PeachPuff);
        }
    }
}
