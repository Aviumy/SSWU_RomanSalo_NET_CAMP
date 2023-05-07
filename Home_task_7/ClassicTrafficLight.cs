using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7
{
    internal class ClassicTrafficLight : TrafficLight
    {
        public ClassicTrafficLight(string name, State initialState, Dictionary<State, uint> stateSwitchTimes)
            : base(name, initialState, stateSwitchTimes)
        {
            _strategy = new ClassicTrafficLightStrategy();
            _possibleStates = new State[]
            {
                State.Red,
                State.RedAndYellow,
                State.Green,
                State.BlinkingGreen,
                State.Yellow,
            };
        }
    }
}
