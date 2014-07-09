using Game;
using Game.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Fish: Monster
    {
        public Fish(World world)
            : base(world)
        {

        }
        protected override Vector NextStep(World world)
        {

            MyVector.X = world.rnd.Next(-1, 2);
            MyVector.Y = world.rnd.Next(-1, 2);
            return MyVector;
        }

        protected override void TimerTick(object source, System.Timers.ElapsedEventArgs e)
        {
            NextStep(world);
            Position pp = new Position() { X = MyPosition.X, Y = MyPosition.Y };
            pp.Add(MyVector, this.Speed);
            Go(world.GetCell(pp));
            if (EatPlayer(world.GetPlayer()))
            {
                // world.timer.Stop();
                // world.Generate(world.CellWidth, world.CellHeight);
            }
        }

        protected override bool GoToCell(Cell cell)
        {
            if (cell!=null)
            if (cell.Level == 2) return true;
            return false;
        }

        private bool delFunc(Player player, Monster m)
        {
            if (Math.Sqrt((player.MyPosition.X - m.MyPosition.X) * (player.MyPosition.X - m.MyPosition.X) +
                (player.MyPosition.Y - m.MyPosition.Y) * (player.MyPosition.Y - m.MyPosition.Y)) < 12) return true;
            return false;
        }
        protected override void SpeedUpdate()
        {
            Speed = 3;
        }
    }
}
