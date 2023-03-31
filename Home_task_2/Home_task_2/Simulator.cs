namespace Home_task_2
{
    public class Simulator
    {
        private readonly WaterTower _tower;
        private readonly List<User> _users;

        public Simulator(WaterTower tower, List<User> users)
        {
            _tower = tower;
            _users = users.Select(x => x).ToList();
        }

        public void Simulate() 
        {

        }
    }
}
