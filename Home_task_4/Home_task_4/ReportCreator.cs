namespace Home_task_4
{
    public class ReportCreator
    {
        public int FlatsCount { get; private set; }
        public int QuarterNumber { get; private set; }
        public double KwCost { get; private set; }

        private List<EnergyConsumptionInfo> _flatsInfo;

        public ReportCreator()
        {
            _flatsInfo = new List<EnergyConsumptionInfo>();
            KwCost = 2;
        }

        public void ReadFromTextFile(string path)
        {
            using (var reader = new StreamReader(path))
            {

            }
        }

        public string CreateReportForAllFlats()
        {
            return "";
        }

        public string CreateReportForOneFlat(int flatNumber)
        {
            return "";
        }

        public string FindGreatestDebtor()
        {
            return "";
        }

        public int[] FindFlatsWithNoEnergyUsed()
        {
            return new int[0];
        }
    }
}
