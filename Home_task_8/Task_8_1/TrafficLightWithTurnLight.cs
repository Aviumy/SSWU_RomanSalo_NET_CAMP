﻿using System;
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

            if (_possibleStates.Length + _possibleTurnStates.Length != stateSwitchTimes.Count)
            {
                throw new ArgumentException("Count of states (of main and turn lights) and count of switch times should match.");
            }
            foreach (var state in stateSwitchTimes.Keys)
            {
                if (!_possibleStates.Contains(state) && !_possibleTurnStates.Contains(state))
                {
                    throw new ArgumentException($"Unexpected state found: {state}.");
                }
            }

            if (!_possibleStates.Contains(initialState))
            {
                throw new ArgumentException($"Invalid initial main lights state was set: {initialState}.");
            }
            if (!_possibleTurnStates.Contains(initialTurnState))
            {
                throw new ArgumentException($"Invalid initial turn light state was set: {initialTurnState}.");
            }

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
            if (TurnLightState == State.TurnOff)            
                TurnLightState = State.TurnOn;            
            else if (TurnLightState == State.TurnOn)            
                TurnLightState = State.BlinkingTurn;            
            else if (TurnLightState == State.BlinkingTurn)            
                TurnLightState = State.TurnOff;            
            else
                throw new ArgumentException($"Invalid turn light state: {TurnLightState}");            

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
