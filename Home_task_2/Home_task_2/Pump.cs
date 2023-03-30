using System.Text;

namespace Home_task_2
{
    public class Pump
    {
        public double Power { get; private set; }

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
