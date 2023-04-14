namespace Home_task_4
{
    public class EnergyConsumptionInfo
    {
        public int FlatNumber { get; private set; }
        public string Address { get; private set; }
        public string Surname { get; private set; }
        public int FirstCounterValue { get; private set; }
        public int LastCounterValue { get; private set; }
        public DateOnly[] CounterReadingDates { get; private set; }

        public EnergyConsumptionInfo(int flatNumber, string address, string surname, int firstCounterValue, int lastCounterValue, DateOnly[] counterReadingDates)
        {
            FlatNumber = flatNumber;
            Address = address;
            Surname = surname;
            FirstCounterValue = firstCounterValue;
            LastCounterValue = lastCounterValue;
            CounterReadingDates = counterReadingDates;
        }
    }
}
