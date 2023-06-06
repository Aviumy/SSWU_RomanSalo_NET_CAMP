using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_2
{
    using static PriceCountVisitorConfig;

    // Конкретний відвідувач робимо вкладеним класом у Product, щоб не порушувати інкапсуляцію властивостей Product
    internal abstract partial class Product
    {
        public class PriceCountVisitor : ProductVisitor
        {
            public void VisitFood(Food food)
            {
                var daysToExpire = food.ExpiryDate.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber;
                if (daysToExpire < daysToExpireThreshold)
                {
                    food.TotalPrice = food.Price + (daysToExpireThreshold - daysToExpire) * urgencyPriceMultiplier;
                }
            }

            public void VisitDevice(Device device)
            {
                var size = device.Size;
                if (size.width > widthThreshold ||
                    size.height > heightThreshold || 
                    size.length > lengthThreshold)
                {
                    device.TotalPrice = device.Price * deviceSizePriceMultiplier;
                }
            }

            public void VisitClothes(Clothes clothes)
            {
                clothes.TotalPrice = clothes.Price + (int)clothes.Size * clothesSizePriceMultiplier;
            }
        }
    }
}
