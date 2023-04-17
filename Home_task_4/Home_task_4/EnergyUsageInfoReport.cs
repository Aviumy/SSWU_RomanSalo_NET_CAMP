using System.Globalization;
using System.Text;

namespace Home_task_4
{
    internal class EnergyUsageInfoReportCreator
    {
        private EnergyUsageInfoService _service;

        public EnergyUsageInfoReportCreator(EnergyUsageInfoService service)
        {
            _service = service;
        }

        public string CreateForAllFlats()
        {
            StringBuilder table = new StringBuilder();
            CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
            var flatsInfo = _service.GetAllFlatsInfo();

            int month = (_service.QuarterNumber - 1) * 3 + 1;
            for (int i = month; i <= month + 2; i++)
            {
                table.Append(CreateTableHeader(i));
                foreach (var info in flatsInfo)
                {
                    int index = (i - 1) % 3;
                    table.Append(CreateOneTableEntry(info, index));
                }
                table.AppendLine();
            }

            return table.ToString();
        }

        public string CreateForOneFlat(int flatNumber)
        {
            StringBuilder table = new StringBuilder();
            CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
            var info = _service.GetOneFlatInfo(flatNumber);

            int month = (_service.QuarterNumber - 1) * 3 + 1;
            for (int i = month; i <= month + 2; i++)
            {
                table.Append(CreateTableHeader(i));
                int index = (i - 1) % 3;
                table.AppendLine(CreateOneTableEntry(info, index));
            }

            return table.ToString();
        }

        private string CreateTableHeader(int month)
        {
            StringBuilder sb = new StringBuilder();

            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
            monthName = $"{char.ToUpperInvariant(monthName[0])}{monthName.Substring(1)}";
            sb.AppendLine($"{monthName}:");
            sb.AppendLine($"Квартира |            Власник | Поперед. показ | Поточний показ | Дата пот. показу |       До сплати");
            sb.AppendLine($"=========+====================+================+================+==================+================");
        
            return sb.ToString();
        }

        private string CreateOneTableEntry(EnergyUsageInfo? info, int i)
        {
            StringBuilder sb = new StringBuilder();

            if (info != null)
            {
                sb.Append($"{info.FlatNumber} | ".PadLeft(11));
                sb.Append($"{info.Surname} | ".PadLeft(21));
                sb.Append($"{info.CounterReadings[i]} | ".PadLeft(17));
                sb.Append($"{info.CounterReadings[i + 1]} | ".PadLeft(17));
                sb.Append($"{info.CounterReadingDates[i]:dd.MM.yy} | ".PadLeft(19));
                double cost = (info.CounterReadings[i + 1] - info.CounterReadings[i]) * EnergyUsageInfo.KwCost;
                sb.AppendLine($"{Math.Round(cost, 2).ToString("C", CultureInfo.CurrentCulture)}".PadLeft(15));
            }

            return sb.ToString();
        }
    }
}
