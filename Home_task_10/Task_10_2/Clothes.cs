using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_2
{
    internal class Clothes : Product
    {
        public ClothingSize Size { get; protected set; }

        public Clothes(int id, string name, decimal price, ClothingSize size)
            : base(id, name, price)
        {
            Size = size;
        }

        public override void CountTotalPrice(ProductVisitor visitor)
        {
            visitor.VisitClothes(this);
        }
    }
}
