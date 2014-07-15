using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Monsters
{
    public abstract class Monster : Unit
    {

        public string Name {get; set;}

        public delegate void EatPlayerHandler(Monster monster, Player player);
        public event EatPlayerHandler EatPlayerEvent;
         
        public Monster(World world)
            : base(world)
        {
 
        }

        protected virtual void FuncEatPlayerEvent(Monster monster, Player player)
        {
            EatPlayerHandler handler = EatPlayerEvent;
            if (EatPlayerEvent != null) handler(monster, player);
        }

        public override void TimerTick(object source, System.Timers.ElapsedEventArgs e)
        {
            NextStep(world);
            Position pp = new Position() { X = MyPosition.X, Y = MyPosition.Y };
            pp.Add(MyVector, this.Speed);
            Go(world.GetCell(pp));
            if (EatPlayer(world.GetPlayer()))
            {
                FuncEatPlayerEvent(this, world.OnePlayer);
            }

            Debug.WriteLine("{0}", this.Name);
        }

        public void Stop()
        {
            world.WorldTimer.Elapsed -= TimerTick;
        }

        protected abstract Vector NextStep(World world);

        protected bool EatPlayer(Player player)
        {
            //m.EatPlayer();
            if (Colision(player, this))
            {
                //FuncEatPlayerEvent(this, player);
                return true;
            }
            return false;
        }

        protected bool Colision(Player player, Monster m)
        {
            if (Math.Sqrt((player.MyPosition.X - m.MyPosition.X) * (player.MyPosition.X - m.MyPosition.X) +
                (player.MyPosition.Y - m.MyPosition.Y) * (player.MyPosition.Y - m.MyPosition.Y)) < (world.SideSizeH+world.SideSizeW)/6) return true;
            return false;
        }
       
    }
}
