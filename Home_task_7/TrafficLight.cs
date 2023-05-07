using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7
{
    public enum State
    {
        Red,
        RedAndYellow,
        Green,
        BlinkingGreen,
        Yellow,
    }

    internal abstract class TrafficLight
    {
        protected SwitchStateStrategy _strategy;
        protected State[] _possibleStates;
        protected Dictionary<State, uint> _stateTimes;

        protected TrafficLight(string name, State initialState, Dictionary<State, uint> stateSwitchTimes)
        {
            Name = name;
            CurrState = initialState;

            _stateTimes = new Dictionary<State, uint>();
            foreach (var key in stateSwitchTimes.Keys)
            {
                _stateTimes.Add(key, stateSwitchTimes[key]);
            }

            StateTimeLeft = stateSwitchTimes[initialState];
        }

        public string Name { get; protected set; }
        public State CurrState { get; protected set; }
        public uint StateTimeLeft { get; protected set; }
        public State[] PossibleStates
        {
            get
            {
                return _possibleStates.Select(x => x).ToArray();
            }
        }

        public void SwitchState()
        {
            CurrState = _strategy.ChangeState(CurrState);
            StateTimeLeft = _stateTimes[CurrState];
        }

        public void DecrementStateTime()
        {
            if (--StateTimeLeft == 0)
            {
                SwitchState();
            }
        }

        public void ChangeStateTimes(uint[] newStateTimes)
        {
            if (newStateTimes == null)
            {
                Console.WriteLine("Array of state switch times should not be null.");
            }
            else
            {
                if (newStateTimes.Length != _possibleStates.Length)
                {
                    Console.WriteLine("States count and count of state switch times should match.");
                }
                else
                {
                    for (int i = 0; i < newStateTimes.Length; i++)
                    {
                        _stateTimes[_possibleStates[i]] = newStateTimes[i];
                        if (CurrState == _possibleStates[i])
                        {
                            StateTimeLeft = newStateTimes[i];
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Світлофор: {Name} | ");
            result.AppendLine($"Колір: {CurrState}\t({StateTimeLeft} с)");
            return result.ToString();
        }
    }
}
