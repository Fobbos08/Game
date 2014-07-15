using Game.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player : Unit
    {
        public delegate void EatBonusHandler(Bonus bonus, Player player);
        public event EatBonusHandler EatBonusEvent;


        protected virtual void FuncEatPlayerEvent(Bonus bonus, Player player)
        {
            EatBonusHandler handler = EatBonusEvent;
            if (EatBonusEvent != null) handler(bonus, player);
        }


        public Player(World world) : base (world)
        {
            MovedLevel = 1;
            MyVector = new Vector();
        }

        public bool EatBonus(Bonus bonus)
        {
            if (bonus == null) return false;
            
            if (bonus.MyPosition.X == MyPosition.X / world.SideSizeW && bonus.MyPosition.Y == MyPosition.Y / world.SideSizeH)
            {
                FuncEatPlayerEvent(bonus, this);
                return true;
            } 
            return false;
        }

        public override void TimerTick(object source, System.Timers.ElapsedEventArgs e)
        {
            Position pp = new Position() { X = MyPosition.X, Y = MyPosition.Y };
            pp.Add(MyVector, this.Speed);
            Go(world.GetCell(pp));
            if (EatBonus(world.GetBonus(this))) world.GetBonus(this).EatIt(this);
            
        }

        protected override void SpeedUpdate()
        {
            Speed = (int)(Speed * 1.5);
            if (Speed > 4) Speed = 4;
        }

    }
}
