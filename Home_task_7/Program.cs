using System.Text;

namespace Home_task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Task_7();
        }

        static void Task_7()
        {
            var trafficLightStateTimes = new Dictionary<State, uint>()
            {
                [State.Red] = 7,
                [State.RedAndYellow] = 1,
                [State.Green] = 4,
                [State.BlinkingGreen] = 1,
                [State.Yellow] = 1,
            };
            List<TrafficLight> trafficLights = new List<TrafficLight>()
            {
                new ClassicTrafficLight("Пн-Пд", State.RedAndYellow, trafficLightStateTimes),
                new ClassicTrafficLight("Пд-Пн", State.RedAndYellow, trafficLightStateTimes),
                new ClassicTrafficLight("Зх-Сх", State.Red, trafficLightStateTimes),
                new ClassicTrafficLight("Сх-Зх", State.Red, trafficLightStateTimes),
            };
            foreach (var trafficLight in trafficLights)
            {
                trafficLight.NewStateTimesIsNull += () => Console.WriteLine("Array of state switch times should not be null.");
                trafficLight.NewStateTimesCountDoesntMatch += () => Console.WriteLine("Count of states and count of switch times should match.");
            }
            Simulator simulator = new Simulator(trafficLights);

            // Перевірка на те, чи правильно реалізована глибока копія
            trafficLightStateTimes[State.Yellow] = 555;
            trafficLights[1].PossibleStates[0] = State.Green;
            simulator.TrafficLights[1].PossibleStates[0] = State.RedAndYellow;

            Console.WriteLine(simulator);
            foreach (uint s in simulator.SimulateNSeconds(14))
            {
                Console.WriteLine(simulator);
            }

            // Змінюємо час переключання світлофорів
            Console.WriteLine("=========Змінюємо час переключення станів світлофорів=========");
            uint[] newStateTimes = new uint[] { 8, 1, 5, 1, 1 };
            simulator.TrafficLights[0].ChangeStateTimes(newStateTimes);
            simulator.TrafficLights[1].ChangeStateTimes(newStateTimes);
            simulator.TrafficLights[2].ChangeStateTimes(newStateTimes);
            simulator.TrafficLights[3].ChangeStateTimes(newStateTimes);

            Console.WriteLine(simulator);
            foreach (uint s in simulator.SimulateNSeconds(16))
            {
                Console.WriteLine(simulator);
            }

            // Тест подій
            simulator.TrafficLights[0].ChangeStateTimes(new uint[] { 0, 0 });
            simulator.TrafficLights[0].ChangeStateTimes(null);
        }
    }
}