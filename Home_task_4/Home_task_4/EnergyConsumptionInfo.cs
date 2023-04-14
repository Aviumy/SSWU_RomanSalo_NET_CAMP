namespace Home_task_4
{
    public class EnergyConsumptionInfo
    {
        public int FlatNumber { get; private set; }
        public string Address { get; private set; }
        public string Surname { get; private set; }
        public int[] CounterReadings { get; private set; }
        public DateOnly[] CounterReadingDates { get; private set; }

        public EnergyConsumptionInfo(int flatNumber, string address, string surname, int[] counterReadings, DateOnly[] counterReadingDates)
        {
            FlatNumber = flatNumber;
            Address = address;
            Surname = surname;
            CounterReadings = counterReadings;
            CounterReadingDates = counterReadingDates;
        }
    }
}
