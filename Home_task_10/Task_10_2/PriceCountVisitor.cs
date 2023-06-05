using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_2
{
    // Конкретний відвідувач робимо вкладеним класом у Product, щоб не порушувати інкапсуляцію властивостей Product
    internal abstract partial class Product
    {
        public class PriceCountVisitor : ProductVisitor
        {
            public void VisitFood(Food food)
            {
                var daysToExpire = food.ExpiryDate.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber;
                if (daysToExpire < 3)
                {
                    food.TotalPrice = food.Price + (3 - daysToExpire) * 5m;
                }
            }

            public void VisitDevice(Device device)
            {
                var size = device.Size;
                if (size.width > 15 || size.height > 6 || size.length > 15)
                {
                    device.TotalPrice = device.Price * 1.2m;
                }
            }

            public void VisitClothes(Clothes clothes)
            {
                clothes.TotalPrice = clothes.Price + (int)clothes.Size * 11m;
            }
        }
    }
}
