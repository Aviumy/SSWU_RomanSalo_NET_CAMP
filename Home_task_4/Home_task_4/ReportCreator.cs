using System.Globalization;
using System.Text;
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
            KwCost = 2.175245;
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

                    EnergyConsumptionInfo flatInfo = new EnergyConsumptionInfo(
                        flatNumber: flatNumber,
                        address: address,
                        surname: surname,
                        counterReadings: readings.ToArray(),
                        counterReadingDates: dates.ToArray()
                    );
                    _flatsInfo.Add(flatInfo);
                }
            }
        }

        public string CreateReportForAllFlats()
        {
            StringBuilder sb = new StringBuilder();
            CultureInfo.CurrentCulture = new CultureInfo("uk-UA");

            for (int i = 0; i < 3; i++)
            {
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1);
                month = $"{char.ToUpperInvariant(month[0])}{month.Substring(1)}";
                sb.AppendLine($"{month}:");
                sb.AppendLine($"Квартира |            Власник | Поперед. показ | Поточний показ | Дата пот. показу |       До сплати");
                sb.AppendLine($"=========+====================+================+================+==================+================");
                foreach (var info in _flatsInfo)
                {
                    sb.Append($"{info.FlatNumber} | ".PadLeft(11));
                    sb.Append($"{info.Surname} | ".PadLeft(21));
                    sb.Append($"{info.CounterReadings[i]} | ".PadLeft(17));
                    sb.Append($"{info.CounterReadings[i + 1]} | ".PadLeft(17));
                    sb.Append($"{info.CounterReadingDates[i]:dd.MM.yy} | ".PadLeft(19));
                    double cost = (info.CounterReadings[i + 1] - info.CounterReadings[i]) * KwCost;
                    sb.AppendLine($"{Math.Round(cost, 2).ToString("C", CultureInfo.CurrentCulture)}".PadLeft(15));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string CreateReportForOneFlat(int flatNumber)
        {
            StringBuilder sb = new StringBuilder();
            CultureInfo.CurrentCulture = new CultureInfo("uk-UA");

            for (int i = 0; i < 3; i++)
            {
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1);
                month = $"{char.ToUpperInvariant(month[0])}{month.Substring(1)}";
                sb.AppendLine($"{month}:");
                sb.AppendLine($"Квартира |            Власник | Поперед. показ | Поточний показ | Дата пот. показу |       До сплати");
                sb.AppendLine($"=========+====================+================+================+==================+================");

                var info = _flatsInfo.First(x => x.FlatNumber == flatNumber);
                sb.Append($"{info.FlatNumber} | ".PadLeft(11));
                sb.Append($"{info.Surname} | ".PadLeft(21));
                sb.Append($"{info.CounterReadings[i]} | ".PadLeft(17));
                sb.Append($"{info.CounterReadings[i + 1]} | ".PadLeft(17));
                sb.Append($"{info.CounterReadingDates[i]:dd.MM.yy} | ".PadLeft(19));
                double cost = (info.CounterReadings[i + 1] - info.CounterReadings[i]) * KwCost;
                sb.AppendLine($"{Math.Round(cost, 2).ToString("C", CultureInfo.CurrentCulture)}".PadLeft(15));
                
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string FindGreatestDebtor()
        {
            string surname = string.Empty;
            double maxCost = 0;
            foreach (var info in _flatsInfo)
            {
                double cost = (info.CounterReadings.Last() - info.CounterReadings[0]) * KwCost;
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
            foreach (var info in _flatsInfo)
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
