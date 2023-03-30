using System.Text;

namespace Home_task_2
{
    public abstract class Pump
    {
        private double _power;

        public double Power 
        { 
            get => _power; 
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Pump power can not be less or equal 0.");
                else
                    _power = value;
            }
        }

        public Pump(double power)
        {
            Power = power;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Power: {Power}");
            return sb.ToString();
        }
    }
}
