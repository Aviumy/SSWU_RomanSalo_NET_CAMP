using System.Text;

namespace Home_task_2
{
    public class WaterTower
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

        public void IncreaseAmount()
        {
            if (_currentAmount + _pump.Power > _maxAmount)
            {
                _currentAmount = _maxAmount;
                Console.WriteLine("Max water amount reached!");
            }
            else
            {
                _currentAmount += _pump.Power;
            }
        }

        public void DecreaseAmount(double amount)
        {
            if (_currentAmount == 0)
            {
                Console.WriteLine("There is no water!");
            }
            else if (_currentAmount < amount)
            {
                _currentAmount = 0;
                Console.WriteLine("Water is over!");
            }
            else
            {
                _currentAmount -= amount;
            }
        }

        public bool IsEmpty()
        {
            return _currentAmount == 0;
        }

        public bool IsFull()
        {
            return _currentAmount == _maxAmount;
        }
    }
}
