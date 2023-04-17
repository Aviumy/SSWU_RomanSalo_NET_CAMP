using System.Globalization;
using System.Text;

namespace Home_task_4
{
    internal class EnergyUsageInfoReport
    {
        public int FlatsCount { get; private set; }
        public int QuarterNumber { get; private set; }

        private EnergyUsageInfoService _service;

        public EnergyUsageInfoReport(EnergyUsageInfoService service)
        {
            _service = service;
        }

        public string CreateForAllFlats()
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
                var flatsInfo = _service.GetAllFlatsInfo();
                foreach (var info in flatsInfo)
                {
                    sb.Append($"{info.FlatNumber} | ".PadLeft(11));
                    sb.Append($"{info.Surname} | ".PadLeft(21));
                    sb.Append($"{info.CounterReadings[i]} | ".PadLeft(17));
                    sb.Append($"{info.CounterReadings[i + 1]} | ".PadLeft(17));
                    sb.Append($"{info.CounterReadingDates[i]:dd.MM.yy} | ".PadLeft(19));
                    double cost = (info.CounterReadings[i + 1] - info.CounterReadings[i]) * EnergyUsageInfo.KwCost;
                    sb.AppendLine($"{Math.Round(cost, 2).ToString("C", CultureInfo.CurrentCulture)}".PadLeft(15));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string CreateForOneFlat(int flatNumber)
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

                var info = _service.GetOneFlatInfo(flatNumber);
                sb.Append($"{info.FlatNumber} | ".PadLeft(11));
                sb.Append($"{info.Surname} | ".PadLeft(21));
                sb.Append($"{info.CounterReadings[i]} | ".PadLeft(17));
                sb.Append($"{info.CounterReadings[i + 1]} | ".PadLeft(17));
                sb.Append($"{info.CounterReadingDates[i]:dd.MM.yy} | ".PadLeft(19));
                double cost = (info.CounterReadings[i + 1] - info.CounterReadings[i]) * EnergyUsageInfo.KwCost;
                sb.AppendLine($"{Math.Round(cost, 2).ToString("C", CultureInfo.CurrentCulture)}".PadLeft(15));

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
