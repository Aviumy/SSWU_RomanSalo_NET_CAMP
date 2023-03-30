using System.Text;

namespace Home_task_2
{
    public class User
    {
        private readonly long _id;
        private double _consumption;

        private WaterTower _tower;

        public User(double consumption, WaterTower tower)
        {
            _id = DateTime.Now.Ticks;
            _consumption = consumption;
            _tower = tower;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"User {_id}");
            sb.AppendLine($"Consumption rate: {_consumption}");
            return sb.ToString();
        }

        public void UseWater()
        {
            _tower.DecreaseAmount(_consumption);
        }
    }
}
