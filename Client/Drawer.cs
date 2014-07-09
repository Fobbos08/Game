using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using System.Drawing;
using Game.Monsters;

namespace Client
{
    public class Drawer
    {
        Graphics g;
        Pen p;

        public Drawer(Bitmap bitmap)
        {
            p = new Pen(Color.Aquamarine);
            g = Graphics.FromImage(bitmap);
        }
        public void Draw(World world)
        {
            if (world.flag == false)
            {
                int sideSizeW = world.sideSizeW;
                int sideSizeH = world.sideSizeH;
                //draw world
                Brush b = new SolidBrush(Color.Gray);
                for (int i = 0; i < world.CellWidth; i++)
                    for (int j = 0; j < world.CellHeight; j++)
                    {
                        Cell c = world.map[i, j];
                        if (c != null)
                        {
                            if (c.Level == 0) p.Color = Color.Gray;
                            if (c.Level == 1) p.Color = Color.Green;
                            if (c.Level == 2) p.Color = Color.Blue;

                            if (c.Level == 0) b = new SolidBrush(Color.Gray);
                            if (c.Level == 1) b = new SolidBrush(Color.Green);
                            if (c.Level == 2) b = new SolidBrush(Color.Blue);
                            g.FillRectangle(b, i * sideSizeW, j * sideSizeH, sideSizeW, sideSizeH);


                            if (c.bonus != null)
                            {
                                b = new SolidBrush(Color.Gold);
                                g.FillEllipse(b, i * sideSizeW + sideSizeW / 4, j * sideSizeH + sideSizeH / 4, sideSizeW / 2, sideSizeH / 2);
                            }
                        }
                    }
                //draw player
                b = new SolidBrush(Color.Indigo);
                g.FillEllipse(b, world.GetPlayer().MyPosition.X - sideSizeW / 4, world.GetPlayer().MyPosition.Y - sideSizeH / 4, sideSizeW / 2, sideSizeH / 2);
                //draw monster
                

                List<Monster> m = world.GetMonsters();
                foreach (var mo in m)
                {
                    if (mo.Name == "WOLF")
                    {
                        b = new SolidBrush(Color.Lavender);
                    }
                    if (mo.Name == "BIRD") 
                    {
                        b = new SolidBrush(Color.Crimson);
                    }
                    if (mo.Name == "FISH")
                    {
                        b = new SolidBrush(Color.Fuchsia);
                    }
                    g.FillEllipse(b, mo.MyPosition.X - sideSizeW / 4, mo.MyPosition.Y - sideSizeH / 4, sideSizeW / 2, sideSizeH / 2);
                }
            }
            
        }
    }
}
