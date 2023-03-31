namespace Home_task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pump = new Pump(20);
            var tower = new WaterTower(100, pump);
            var users = new List<User>()
            {
                new User(10, tower),
                new User(15, tower),
            };

            var simulator = new Simulator(tower, users);
            simulator.Simulate();
        }
    }
}