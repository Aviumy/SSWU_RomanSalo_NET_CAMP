using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_1
{
    internal class TrafficLightValidator
    {
        public static void CheckCurrentState(State[] possibleStates, State currState)
        {
            if (!possibleStates.Contains(currState))
                throw new ArgumentException($"Invalid traffic light state: {currState}");
        }

        public static void MatchStateCount(State[] possibleStates, Dictionary<State, uint> stateSwitchTimes)
        {
            if (possibleStates.Length != stateSwitchTimes.Count)
            {
                throw new ArgumentException("Count of states and count of switch times should match.");
            }
        }

        internal static void CheckForUnexpectedStates(State[] possibleStates, Dictionary<State, uint> stateSwitchTimes)
        {
            foreach (var state in stateSwitchTimes.Keys)
            {
                if (!possibleStates.Contains(state))
                {
                    throw new ArgumentException($"Unexpected state found: {state}.");
                }
            }
        }

        internal static void CheckInitialState(State[] possibleStates, State initialState)
        {
            if (!possibleStates.Contains(initialState))
            {
                throw new ArgumentException($"Invalid initial state was set: {initialState}.");
            }
        }

        internal static void ValidateStateTimeForZero(uint stateTime)
        {
            if (stateTime == 0)
            {
                throw new ArgumentException("State time should not be set as zero.");
            }
        }
    }
}
