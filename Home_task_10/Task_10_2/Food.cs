using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_2
{
    internal class Food : Product
    {
        public DateOnly ExpiryDate { get; protected set; }

        public Food(int id, string name, decimal price, DateOnly expiryDate) 
            : base(id, name, price)
        {
            ExpiryDate = expiryDate;
        }

        public override void CountTotalPrice(ProductVisitor visitor)
        {
            visitor.VisitFood(this);
        }
    }
}
