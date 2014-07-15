using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Monsters
{
    public class Bird:Monster
    {
        public Bird(World world)
            : base(world)
        {
            MovedLevel = 2;
        }

        protected override Vector NextStep(World world)
        {

            MyVector.X = world.RND.Next(-1, 2);
            MyVector.Y = world.RND.Next(-1, 2);
            return MyVector;
        }

        //protected override void TimerTick(object source, System.Timers.ElapsedEventArgs e)
        //{
        //    NextStep(world);
        //    Position pp = new Position() { X = MyPosition.X, Y = MyPosition.Y };
        //    pp.Add(MyVector, this.Speed);
        //    //Position tmp = MyPosition;
        //    Go(world.GetCell(pp));
        //    if (EatPlayer(world.GetPlayer()))
        //    {
        //        FuncEatPlayerEvent(this, world.OnePlayer);
        //        // world.timer.Stop();
        //        // world.Generate(world.CellWidth, world.CellHeight);
        //    }
        //}

        private bool delFunc(Player player, Monster m)
        {
            if (Math.Sqrt((player.MyPosition.X - m.MyPosition.X) * (player.MyPosition.X - m.MyPosition.X) +
                (player.MyPosition.Y - m.MyPosition.Y) * (player.MyPosition.Y - m.MyPosition.Y)) < 12) return true;
            return false;
        }

        protected override void SpeedUpdate()
        {
            Speed =3;
        }
    }
}
