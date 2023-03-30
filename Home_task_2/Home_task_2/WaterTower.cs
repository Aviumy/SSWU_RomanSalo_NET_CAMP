using System.Text;

namespace Home_task_2
{
    public abstract class WaterTower
    {
        private readonly double _maxAmount;
        private double _currentAmount;

        private Pump _pump;

        public WaterTower(double maxAmount, Pump pump)
        {
            _maxAmount = maxAmount;
            _currentAmount = 0;
            _pump = pump;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Water amount: {_currentAmount}/{_maxAmount}");
            sb.Append($"Pump installed: {_pump}");
            return sb.ToString();
        }

        public abstract void IncreaseAmount();

        public abstract void DecreaseAmount(double amount);

        public abstract bool IsEmpty();

        public abstract bool IsFull();
    }
}
