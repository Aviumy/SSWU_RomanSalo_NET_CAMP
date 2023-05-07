using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7
{
    internal class Simulator
    {
        private List<TrafficLight> _trafficLights;

        public int SimulationTime { get; private set; }

        public Simulator(List<TrafficLight> trafficLights)
        {
            _trafficLights = trafficLights.Select(x => x).ToList();
            SimulationTime = 0;
        }

        public TrafficLight[] TrafficLights
        {
            get
            {
                return _trafficLights.Select(x => x).ToArray();
            }
        }

        public void SimulateOneSecond()
        {
            SimulationTime++;
            foreach (var trafficLight in _trafficLights)
            {
                trafficLight.DecrementStateTime();
            }
        }

        public IEnumerable<uint> SimulateNSeconds(uint n)
        {
            for (uint i = 0; i < n; i++)
            {
                SimulateOneSecond();
                yield return i + 1;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Час симуляції: {SimulationTime} с");
            foreach (var trafficLight in _trafficLights)
            {
                result.Append(trafficLight);
            }
            return result.ToString();
        }
    }
}
