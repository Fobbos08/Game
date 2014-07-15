using Drawer.CellDrawer;
using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class MapDrawer
    {
        private Dictionary<string, CellDrawer.CellDrawer> cellDrawers = new Dictionary<string, CellDrawer.CellDrawer>();
        private LoadEntity le = new LoadEntity();

        public MapDrawer()
        {
            CellDrawer.CellDrawer cd = new GroundDrawer();
            cellDrawers.Add(cd.Name, cd);
            cd = new GrassDrawer();
            cellDrawers.Add(cd.Name, cd);
            cd = new WaterDrawer();
            cellDrawers.Add(cd.Name, cd);
            foreach (var value in le.LoadCells())
            {
                if (!cellDrawers.ContainsKey(value.Name))
                cellDrawers.Add(value.Name, value);
            }
        }
        public void Draw(World world, Graphics graphic, double coefW, double coefH)
        {
            for (int i = 0; i < world.CellWidth; i++)
                for (int j = 0; j < world.CellHeight; j++)
                {
                    Cell c = world.map[i, j];
                    if (c!=null)
                    if (cellDrawers.ContainsKey(c.Name))
                        cellDrawers[c.Name].Draw(world,graphic,i*world.SideSizeW, j*world.SideSizeH,coefW, coefH);
                }
        }
    }
}
