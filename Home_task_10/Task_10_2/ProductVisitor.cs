using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_2
{
    internal interface ProductVisitor
    {
        void VisitFood(Food food);
        void VisitDevice(Device device);
        void VisitClothes(Clothes clothes);
    }
}
