using System.Text;

namespace Task_8_1
{
    // Загальна ідея:
    // - Зробити абстрактний клас світлофора зі всіма необхідними полями, методами, властивостями
    //   і успадковувати від нього конкретні світлофори (звичайний, пішохідний, з поворотами і т.д.)
    // - Реалізувати патерн Стратегія. У якості контексту - абстрактний клас світлофора.
    //   Для кожного конкретного (успадкованого від абстрактного) світлофора є своя стратегія,
    //   в якій задається, як саме перемикати стани (кольори).
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
            var classicTrafficLightStateTimes = new Dictionary<State, uint>()
            {
                [State.Red] = 7,
                [State.RedAndYellow] = 1,
                [State.Green] = 4,
                [State.BlinkingGreen] = 1,
                [State.Yellow] = 1,
            };
            var turnTrafficLightStateTimes = new Dictionary<State, uint>()
            {
                [State.Red] = 6,
                [State.RedAndYellow] = 1,
                [State.Green] = 3,
                [State.BlinkingGreen] = 1,
                [State.Yellow] = 1,
                [State.TurnOff] = 3,
                [State.TurnOn] = 2,
                [State.BlinkingTurn] = 1,
            };

            List<TrafficLight> trafficLights = new List<TrafficLight>()
            {
                new ClassicTrafficLight("ТестЗвич", State.RedAndYellow, classicTrafficLightStateTimes),
                new TrafficLightWithTurnLight("ТестПов", Turn.Left, State.RedAndYellow, State.TurnOff, turnTrafficLightStateTimes),
            };
            foreach (var trafficLight in trafficLights)
            {
                trafficLight.NewStateTimesIsNull += () => Console.WriteLine("Array of state switch times should not be null.");
                trafficLight.NewStateTimesCountDoesntMatch += () => Console.WriteLine("Count of states and count of switch times should match.");
            }
            Simulator simulator = new Simulator(trafficLights);

            Console.WriteLine(simulator);
            foreach (uint s in simulator.SimulateNSeconds(14))
            {
                Console.WriteLine(simulator);
            }
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
            simulator.TrafficLights[0].StateTimes[State.RedAndYellow] = 888;
            trafficLights[0].StateTimes[State.Red] = 777;

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