﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_1
{
    internal class ClassicTrafficLight : TrafficLight
    {
        public ClassicTrafficLight(string name, Dictionary<State, uint> stateSwitchTimes, State initialState, uint initialStateTime = uint.MaxValue)
            : base(name, stateSwitchTimes, initialState, initialStateTime)
        {
            _possibleStates = new State[]
            {
                State.Red,
                State.RedAndYellow,
                State.Green,
                State.BlinkingGreen,
                State.Yellow,
            };

            TrafficLightValidator.MatchStateCount(_possibleStates, stateSwitchTimes);
            TrafficLightValidator.CheckForUnexpectedStates(_possibleStates, stateSwitchTimes);
            TrafficLightValidator.CheckInitialState(_possibleStates, initialState);
        }
    }
}
