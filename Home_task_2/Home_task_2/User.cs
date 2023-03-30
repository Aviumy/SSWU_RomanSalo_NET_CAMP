using System.Text;

namespace Home_task_2
{
    public abstract class User
    {
        private readonly long _id;
        private double _consumption;
        private WaterTower _tower;

        public double Consumption
        {
            get => _consumption;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "User's water consumption can not be less than 0.");
                else
                    _consumption = value;
            }
        }

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

        public abstract void UseWater();
    }
}
