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

            if (_possibleStates.Length != stateSwitchTimes.Count)
            {
                throw new ArgumentException("Count of states and count of switch times should match.");
            }
            foreach (var state in stateSwitchTimes.Keys)
            {
                if (!_possibleStates.Contains(state))
                {
                    throw new ArgumentException($"Unexpected state found: {state}.");
                }
            }

            if (!_possibleStates.Contains(initialState))
            {
                throw new ArgumentException($"Invalid initial state was set: {initialState}.");
            }
        }
    }
}
