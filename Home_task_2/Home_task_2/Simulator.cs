namespace Home_task_2
{
    public class Simulator
    {
        private readonly Pump _pump;
        private readonly WaterTower _tower;
        private readonly User _user;

        public Simulator(Pump pump, WaterTower tower, User user)
        {
            _pump = pump;
            _tower = tower;
            _user = user;
        }

        public void Simulate()
        {
            Console.WriteLine(_tower);
            Console.WriteLine(_user);

            while (!_tower.IsFull())
            {
                _tower.IncreaseAmount();
                Console.WriteLine(_tower);
            }
            _tower.IncreaseAmount();
            Console.WriteLine(_tower);

            while (!_tower.IsEmpty())
            {
                _user.UseWater();
                Console.WriteLine(_tower);
            }
            _user.UseWater();
            Console.WriteLine(_tower);
        }
    }
}
