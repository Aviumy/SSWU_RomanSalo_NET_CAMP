using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_1
{
    public enum State
    {
        Red,
        RedAndYellow,
        Green,
        BlinkingGreen,
        Yellow,
        TurnOff,
        TurnOn,
        BlinkingTurn,
    }

    public enum Turn
    {
        Left,
        Right,
    }

    internal abstract class TrafficLight
    {
        static protected State[] _possibleStates;

        protected Dictionary<State, uint> _stateTimes;

        public event Action NewStateTimesIsNull;
        public event Action NewStateTimesCountDoesntMatch;

        protected TrafficLight(string name, Dictionary<State, uint> stateSwitchTimes, State initialState, uint initialStateTime = uint.MaxValue)
        {
            Name = name;
            CurrState = initialState;

            _stateTimes = new Dictionary<State, uint>();
            foreach (var key in stateSwitchTimes.Keys)
            {
                TrafficLightValidator.ValidateStateTimeForZero(stateSwitchTimes[key]);
                _stateTimes.Add(key, stateSwitchTimes[key]);
            }

            TrafficLightValidator.ValidateStateTimeForZero(initialStateTime);
            StateTimeLeft = initialStateTime == uint.MaxValue ? stateSwitchTimes[initialState] : initialStateTime;
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

        public virtual void SwitchState()
        {
            TrafficLightValidator.CheckCurrentState(_possibleStates, CurrState);

            if (CurrState == State.Red)
                CurrState = State.RedAndYellow;
            else if (CurrState == State.RedAndYellow)
                CurrState = State.Green;
            else if (CurrState == State.Green)
                CurrState = State.BlinkingGreen;
            else if (CurrState == State.BlinkingGreen)
                CurrState = State.Yellow;
            else if (CurrState == State.Yellow)
                CurrState = State.Red;
            else
                throw new InvalidOperationException($"Invalid traffic light state: {CurrState}");

            TrafficLightValidator.CheckCurrentState(_possibleStates, CurrState);

            StateTimeLeft = _stateTimes[CurrState];
        }

        public virtual void DecrementStateTime()
        {
            if (--StateTimeLeft == 0)
            {
                SwitchState();
            }
        }

        public virtual void ChangeStateTimes(Dictionary<State, uint> newStateSwitchTimes)
        {
            TrafficLightValidator.MatchStateCount(_possibleStates, newStateSwitchTimes);
            TrafficLightValidator.CheckForUnexpectedStates(_possibleStates, newStateSwitchTimes);

            _stateTimes = new Dictionary<State, uint>();
            foreach (var key in newStateSwitchTimes.Keys)
            {
                TrafficLightValidator.ValidateStateTimeForZero(newStateSwitchTimes[key]);
                _stateTimes.Add(key, newStateSwitchTimes[key]);
            }
            StateTimeLeft = _stateTimes[CurrState];
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{Name}: {CurrState} ({StateTimeLeft} с)");
            return result.ToString();
        }
    }
}
