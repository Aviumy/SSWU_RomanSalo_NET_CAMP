using System.Text.RegularExpressions;

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
                // Parse flats count and quarter number from first line
                string firstLine = reader.ReadLine();
                if (firstLine != null)
                {
                    var firstLineNumbers = Regex.Matches(firstLine, @" \d+");
                    FlatsCount = Convert.ToInt32(firstLineNumbers[0].ToString());
                    QuarterNumber = Convert.ToInt32(firstLineNumbers[1].ToString());
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Parse dates of counter readings
                    List<DateOnly> dates = new List<DateOnly>();
                    var dateMathces = Regex.Matches(line, @"\d{2}\.\d{2}\.\d{4}").Select(x => x.ToString());
                    foreach (string match in dateMathces)
                    {
                        string[] dateValues = match.Split('.');
                        dates.Add(new DateOnly(
                            day: Convert.ToInt32(dateValues[0]),
                            month: Convert.ToInt32(dateValues[1]),
                            year: Convert.ToInt32(dateValues[2])
                        ));
                    }

                    // Parse other values and create info object
                    var values = line.Split("; ");
                    EnergyConsumptionInfo flatInfo = new EnergyConsumptionInfo(
                        flatNumber: Convert.ToInt32(values[0]),
                        address: values[1],
                        surname: values[2],
                        firstCounterValue: Convert.ToInt32(values[3]),
                        lastCounterValue: Convert.ToInt32(values[4]),
                        counterReadingDates: dates.ToArray()
                    );
                    _flatsInfo.Add(flatInfo);
                }
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
