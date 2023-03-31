using System.Text;

namespace Home_task_2
{
    public class WaterTower
    {
        private double _maxAmount;
        private double _currentAmount;
        private Pump? _pump;

        public double MaxAmount
        {
            get => _maxAmount;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Maximum water amount can not be less or equal 0.");
                else
                    _maxAmount = value;
            }
        }

        public double CurrentAmount
        {
            get => _currentAmount;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Water amount can not be less than 0.");
                else
                    _currentAmount = Math.Min(value, _maxAmount);
            }
        }

        public WaterTower(double maxAmount)
        {
            MaxAmount = maxAmount;
            CurrentAmount = 0;
            _pump = null;
        }

        public WaterTower(double maxAmount, Pump pump)
        {
            MaxAmount = maxAmount;
            CurrentAmount = 0;
            _pump = pump;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Water amount: {_currentAmount}/{_maxAmount}");
            sb.Append($"Pump installed: {_pump}");
            return sb.ToString();
        }

        public void IncreaseAmount()
        {

        }

        public void DecreaseAmount(double amount)
        {

        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public void InstallPump(Pump pump)
        {

        }

        public void RemovePump()
        {

        }
    }
}
