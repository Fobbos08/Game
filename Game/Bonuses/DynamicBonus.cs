using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game.Bonuses
{
    public class DynamicBonus : BonusDecorator
    {
        //protected Timer timer;
        int life = 1000;

        public DynamicBonus(World world)
            : base(world)
        {
            world.WorldTimer.Elapsed += new ElapsedEventHandler(TimerTick);
        }

        public override void EatIt(Player player)
        {
            bonus.MyPosition = MyPosition;
            base.EatIt(player);
            world.WorldTimer.Elapsed -= TimerTick; 
            //world.DeleteThisBonus(this);
        }

        protected virtual void TimerTick(object source, ElapsedEventArgs e)
        {
            life--;
            if (life < 0) { world.WorldTimer.Elapsed -= TimerTick; world.DeleteThisBonus(this); }
        }

    }
}
