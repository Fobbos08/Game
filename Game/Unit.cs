using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game
{
    public abstract class Unit
    {
        protected World world;
        public Position MyPosition;
        public int Speed { get; set; }
        public Vector MyVector;
        public int MovedLevel { get; set; }

        public Unit(World world)
        {
            this.world = world;
            world.timer.Elapsed += new ElapsedEventHandler(TimerTick);
        }

        protected virtual void TimerTick(object source, ElapsedEventArgs e) { }

        protected virtual bool GoToCell(Cell cell)
        {
            if (cell == null) return false;
            if (cell.Level <= MovedLevel) return true;
            return false;
        }
        protected void Go(Cell cell)
        {
            if (cell!=null)
            if (GoToCell(cell))
            {
                Move();
            }
        }
        protected void Move()
        {
            Speed = world.GetCell(MyPosition).Speed;
            SpeedUpdate();
            MyPosition.Add(MyVector, Speed);
        }
        protected abstract void SpeedUpdate();
    }
}
