namespace Home_task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pump = new Pump(20);
            var tower = new WaterTower(100, pump);
            var user = new User(10, tower);

            var simulator = new Simulator(pump, tower, user);
            simulator.Simulate();
        }
    }
}