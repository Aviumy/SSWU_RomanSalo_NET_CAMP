using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_2
{
    internal class Device : Product
    {
        public (float width, float height, float length) Size { get; protected set; }

        public Device(int id, string name, decimal price, (float width, float height, float length) size)
            : base(id, name, price)
        {
            Size = size;
        }

        public override void CountTotalPrice(ProductVisitor visitor)
        {
            visitor.VisitDevice(this);
        }
    }
}
