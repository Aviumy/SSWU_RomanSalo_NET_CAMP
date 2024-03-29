﻿using System;
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
        protected ITrafficLightStrategy _strategy;
        protected State[] _possibleStates;
        protected Dictionary<State, uint> _stateTimes;

        public event Action NewStateTimesIsNull;
        public event Action NewStateTimesCountDoesntMatch;

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
        public Dictionary<State, uint> StateTimes
        {
            get
            {
                var copy = new Dictionary<State, uint>();
                foreach (var key in _stateTimes.Keys)
                {
                    copy.Add(key, _stateTimes[key]);
                }
                return copy;
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
                NewStateTimesIsNull?.Invoke();
            }
            else
            {
                if (newStateTimes.Length != _possibleStates.Length)
                {
                    NewStateTimesCountDoesntMatch?.Invoke();
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
            result.Append($"{Name}: {CurrState} ({StateTimeLeft} с)");
            return result.ToString();
        }
    }
}
