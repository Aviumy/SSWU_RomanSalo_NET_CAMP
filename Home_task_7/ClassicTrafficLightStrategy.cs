using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7
{
    internal class ClassicTrafficLightStrategy : SwitchStateStrategy
    {
        public State ChangeState(State currState)
        {
            if (currState == State.Red)
            {
                return State.RedAndYellow;
            }
            else if (currState == State.RedAndYellow)
            {
                return State.Green;
            }
            else if (currState == State.Green)
            {
                return State.BlinkingGreen;
            }
            else if (currState == State.BlinkingGreen)
            {
                return State.Yellow;
            }
            else if (currState == State.Yellow)
            {
                return State.Red;
            }
            else
            {
                throw new ArgumentException("Invalid state!");
            }
        }
    }
}
