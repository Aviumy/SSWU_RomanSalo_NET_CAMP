using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_1
{
    internal interface ITrafficLightStrategy
    {
        State ChangeState(State currState);
    }
}
