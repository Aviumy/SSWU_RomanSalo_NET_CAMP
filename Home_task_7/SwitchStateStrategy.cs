using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7
{
    internal interface SwitchStateStrategy
    {
        State ChangeState(State currState);
    }
}
