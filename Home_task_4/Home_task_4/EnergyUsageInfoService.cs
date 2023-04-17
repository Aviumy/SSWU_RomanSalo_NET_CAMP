using System.Text.RegularExpressions;

namespace Home_task_4
{
    public class EnergyUsageInfoService
    {
        private string _infoFilePath;
        private int _quarterNumber;

        public int FlatsCount { get; private set; }
        public int QuarterNumber {
            get
            {
                return _quarterNumber;
            }
            private set 
            {
                if (value < 1 && value > 4)
                    throw new ArgumentOutOfRangeException("Number of year quarter must be between 1 and 4.");
                _quarterNumber = value;
            }
        }

        public EnergyUsageInfoService(string infoFilePath)
        {
            _infoFilePath = infoFilePath;
        }

        public List<EnergyUsageInfo> GetAllFlatsInfo()
        {
            List<EnergyUsageInfo> _flatsInfo = new List<EnergyUsageInfo>();

            using (var reader = new StreamReader(_infoFilePath))
            {
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
                    var values = line.Split("; ");
                    int flatNumber = Convert.ToInt32(values[0]);
                    string address = values[1];
                    string surname = values[2];

                    List<int> readings = new List<int>();
                    for (int i = 3; i < 7; i++)
                    {
                        readings.Add(Convert.ToInt32(values[i]));
                    }

                    List<DateOnly> dates = new List<DateOnly>();
                    for (int i = 7; i < values.Length; i++)
                    {
                        string[] dateValues = values[i].Split('.');
                        dates.Add(new DateOnly(
                            day: Convert.ToInt32(dateValues[0]),
                            month: Convert.ToInt32(dateValues[1]),
                            year: Convert.ToInt32(dateValues[2])
                        ));
                    }

                    EnergyUsageInfo flatInfo = new EnergyUsageInfo(
                        flatNumber: flatNumber,
                        address: address,
                        surname: surname,
                        counterReadings: readings.ToArray(),
                        counterReadingDates: dates.ToArray()
                    );
                    _flatsInfo.Add(flatInfo);
                }
                if (_flatsInfo.Count != FlatsCount)
                {
                    FlatsCount = _flatsInfo.Count;
                }
            }
            return _flatsInfo;
        }

        public EnergyUsageInfo GetOneFlatInfo(int flatNumber)
        {
            return GetAllFlatsInfo().First(x => x.FlatNumber == flatNumber);
        }

        public string FindGreatestDebtor()
        {
            string surname = string.Empty;
            double maxCost = 0;
            var flatsInfo = GetAllFlatsInfo();
            foreach (var info in flatsInfo)
            {
                double cost = (info.CounterReadings.Last() - info.CounterReadings[0]) * EnergyUsageInfo.KwCost;
                if (cost > maxCost)
                {
                    maxCost = cost;
                    surname = info.Surname;
                }
            }
            return surname;
        }

        public int[] FindFlatsWithNoEnergyUsed()
        {
            List<int> flats = new List<int>();
            var flatsInfo = GetAllFlatsInfo();
            foreach (var info in flatsInfo)
            {
                if (info.CounterReadings.Last() - info.CounterReadings[0] == 0)
                {
                    flats.Add(info.FlatNumber);
                }
            }
            return flats.ToArray();
        }
    }
}
