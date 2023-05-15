using System.Text;

namespace Task_8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Task_7();
            Task_8_1();
        }

        static void Task_8_1()
        {
            var classicAllNSAndCross2WE = new Dictionary<State, uint>()
            {
                [State.Red] = 10,
                [State.RedAndYellow] = 1,
                [State.Green] = 7,
                [State.BlinkingGreen] = 1,
                [State.Yellow] = 1,
            };
            var classicCross1WE = new Dictionary<State, uint>()
            {
                [State.Red] = 12,
                [State.RedAndYellow] = 1,
                [State.Green] = 5,
                [State.BlinkingGreen] = 1,
                [State.Yellow] = 1,
            };
            var turnCross1WE = new Dictionary<State, uint>()
            {
                [State.Red] = 12,
                [State.RedAndYellow] = 1,
                [State.Green] = 5,
                [State.BlinkingGreen] = 1,
                [State.Yellow] = 1,
                [State.TurnOff] = 11,
                [State.TurnOn] = 8,
                [State.BlinkingTurn] = 1,
            };

            List<TrafficLight> trafficLights = new List<TrafficLight>()
            {
                new TrafficLightWithTurnLight("Cross1_Line1_WE_TurnLeft", turnCross1WE, Turn.Left, State.Red, State.TurnOff, turnCross1WE[State.Red] - 2),
                new ClassicTrafficLight("Cross1_Line2_EW", classicCross1WE, State.Red, classicCross1WE[State.Red] - 2),
                new TrafficLightWithTurnLight("Cross1_Line3_EW_TurnLeft", turnCross1WE, Turn.Left, State.Red, State.TurnOff, turnCross1WE[State.Red] - 2),
                new ClassicTrafficLight("Cross1_NS", classicAllNSAndCross2WE, State.RedAndYellow),
                new ClassicTrafficLight("Cross1_SN", classicAllNSAndCross2WE, State.RedAndYellow),

                new ClassicTrafficLight("Cross2_Line1_WE", classicAllNSAndCross2WE, State.Red),
                new ClassicTrafficLight("Cross2_Line2_EW", classicAllNSAndCross2WE, State.Red),
                new ClassicTrafficLight("Cross2_Line3_EW", classicAllNSAndCross2WE, State.Red),
                new ClassicTrafficLight("Cross2_NS", classicAllNSAndCross2WE, State.RedAndYellow),
                new ClassicTrafficLight("Cross2_SN", classicAllNSAndCross2WE, State.RedAndYellow),
            };
            Simulator simulator = new Simulator(trafficLights);

            Console.WriteLine(simulator);
            foreach (uint s in simulator.SimulateNSeconds(20))
            {
                Console.WriteLine(simulator);
            }

            //classicCross1WE[State.Red] = 7;
            //classicCross1WE[State.Green] = 10;
            //simulator.TrafficLights[1].ChangeStateTimes(classicCross1WE);
            //turnCross1WE[State.TurnOff] -= 2;
            //turnCross1WE[State.TurnOn] += 2;
            //simulator.TrafficLights[0].ChangeStateTimes(turnCross1WE);

            //Console.WriteLine("=========Змінюємо час переключання станів світлофорів=========");
            //Console.WriteLine(simulator);
            //foreach (uint s in simulator.SimulateNSeconds(20))
            //{
            //    Console.WriteLine(simulator);
            //}
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
                new ClassicTrafficLight("Пн-Пд", trafficLightStateTimes, State.RedAndYellow),
                new ClassicTrafficLight("Пд-Пн", trafficLightStateTimes, State.RedAndYellow),
                new ClassicTrafficLight("Зх-Сх", trafficLightStateTimes, State.Red),
                new ClassicTrafficLight("Сх-Зх", trafficLightStateTimes, State.Red),
            };
            foreach (var trafficLight in trafficLights)
            {
                //trafficLight.NewStateTimesIsNull += () => Console.WriteLine("Array of state switch times should not be null.");
                //trafficLight.NewStateTimesCountDoesntMatch += () => Console.WriteLine("Count of states and count of switch times should match.");
            }
            Simulator simulator = new Simulator(trafficLights);

            // Перевірка на те, чи правильно реалізована глибока копія
            trafficLightStateTimes[State.Yellow] = 555;
            trafficLights[1].PossibleStates[0] = State.Green;
            simulator.TrafficLights[1].PossibleStates[0] = State.RedAndYellow;
            simulator.TrafficLights[0].StateTimes[State.RedAndYellow] = 888;
            trafficLights[0].StateTimes[State.Red] = 777;

            Console.WriteLine(simulator);
            foreach (uint s in simulator.SimulateNSeconds(14))
            {
                Console.WriteLine(simulator);
            }

            // Змінюємо час переключання світлофорів
            //Console.WriteLine("=========Змінюємо час переключення станів світлофорів=========");
            //uint[] newStateTimes = new uint[] { 8, 1, 5, 1, 1 };
            //simulator.TrafficLights[0].ChangeStateTimes(newStateTimes);
            //simulator.TrafficLights[1].ChangeStateTimes(newStateTimes);
            //simulator.TrafficLights[2].ChangeStateTimes(newStateTimes);
            //simulator.TrafficLights[3].ChangeStateTimes(newStateTimes);

            //Console.WriteLine(simulator);
            //foreach (uint s in simulator.SimulateNSeconds(16))
            //{
            //    Console.WriteLine(simulator);
            //}

            // Тест подій
            //simulator.TrafficLights[0].ChangeStateTimes(new uint[] { 0, 0 });
            //simulator.TrafficLights[0].ChangeStateTimes(null);
        }
    }
}