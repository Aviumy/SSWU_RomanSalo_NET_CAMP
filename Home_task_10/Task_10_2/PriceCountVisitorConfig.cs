using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_2
{
    internal static class PriceCountVisitorConfig
    {
        public static int daysToExpireThreshold = 3;
        public static decimal urgencyPriceMultiplier = 5m;
        
        public static float widthThreshold = 15;
        public static float heightThreshold = 6;
        public static float lengthThreshold = 15;
        public static decimal deviceSizePriceMultiplier = 1.2m;

        public static decimal clothesSizePriceMultiplier = 11m;
    }
}
