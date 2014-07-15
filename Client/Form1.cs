using Game;
using Game.Monsters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drawer;

namespace Client
{
    public partial class Form1 : Form
    {
        World world;
        Bitmap bitmap;
        Drawer.Drawer dr;
        //Drawer1 dr;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(600, 300);
            dr = new Drawer.Drawer(bitmap); 
            //dr = new Drawer1(bitmap);
            world = new World(600,300,20,10);
            world.Generate();
            //dr = new Drawer(bitmap);
            pictureBox1.Image = bitmap;
            dr.Draw(world);
            //dr.Draw(world);
            timer1.Start();
            world.UpdateScoreEvent += UpdateScore;
            
        }

        private void UpdateScore(World w)
        {
            Action p = delegate() { Score.Text = w.Score.ToString(); };
            this.Invoke( p, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap;
            //Score.Text = world.score.ToString();
            dr.Draw(world);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w') { world.GetPlayer().MyVector.X = 0; world.GetPlayer().MyVector.Y = -1; }
            if (e.KeyChar == 'a') { world.GetPlayer().MyVector.X = -1; world.GetPlayer().MyVector.Y = 0; }
            if (e.KeyChar == 's') { world.GetPlayer().MyVector.X = 0; world.GetPlayer().MyVector.Y = 1; }
            if (e.KeyChar == 'd') { world.GetPlayer().MyVector.X = 1; world.GetPlayer().MyVector.Y = 0; }
        }

    }
}
