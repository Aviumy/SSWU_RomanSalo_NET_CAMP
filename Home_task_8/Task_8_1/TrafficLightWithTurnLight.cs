using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_1
{
    internal class TrafficLightWithTurnLight : TrafficLight
    {
        static protected State[] _possibleTurnStates;

        public TrafficLightWithTurnLight(string name, Turn turn, State initialState, State initialTurnState, Dictionary<State, uint> stateSwitchTimes)
            : base(name, initialState, stateSwitchTimes)
        {
            _possibleStates = new State[]
            {
                State.Red,
                State.RedAndYellow,
                State.Green,
                State.BlinkingGreen,
                State.Yellow,
            };
            _possibleTurnStates = new State[]
            {
                State.TurnOff,
                State.TurnOn,
                State.BlinkingTurn,
            };

            var mergedPossibleStates = _possibleStates.Concat(_possibleTurnStates).ToArray();
            TrafficLightValidator.MatchStateCount(mergedPossibleStates, stateSwitchTimes);
            TrafficLightValidator.CheckForUnexpectedStates(mergedPossibleStates, stateSwitchTimes);
            TrafficLightValidator.CheckInitialState(_possibleStates, initialState);
            TrafficLightValidator.CheckInitialState(_possibleTurnStates, initialTurnState);

            Turn = turn;
            TurnLightState = initialTurnState;
            TurnTimeLeft = stateSwitchTimes[initialTurnState];
        }

        public Turn Turn { get; protected set; }
        public State TurnLightState { get; protected set; }
        public uint TurnTimeLeft { get; protected set; }

        public override void DecrementStateTime()
        {
            base.DecrementStateTime();
            if (--TurnTimeLeft == 0)
            {
                SwitchTurn();
            }
        }

        public void SwitchTurn()
        {
            TrafficLightValidator.CheckCurrentState(_possibleTurnStates, TurnLightState);

            if (TurnLightState == State.TurnOff)            
                TurnLightState = State.TurnOn;            
            else if (TurnLightState == State.TurnOn)            
                TurnLightState = State.BlinkingTurn;            
            else if (TurnLightState == State.BlinkingTurn)            
                TurnLightState = State.TurnOff;            
            else
                throw new InvalidOperationException($"Invalid turn light state: {TurnLightState}");

            TrafficLightValidator.CheckCurrentState(_possibleTurnStates, TurnLightState);

            TurnTimeLeft = _stateTimes[TurnLightState];
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{Name}: {CurrState} ({StateTimeLeft} с), поворот {Turn}: {TurnLightState} ({TurnTimeLeft} с)");
            return result.ToString();
        }
    }
}
