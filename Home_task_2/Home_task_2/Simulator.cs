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
        }
    }
}
