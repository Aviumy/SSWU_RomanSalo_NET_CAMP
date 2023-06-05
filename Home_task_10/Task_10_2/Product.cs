using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_2
{
    // Клас оголошено як partial, щоб відділити реалізацію конкретних відвідувачів від власне реалізації цього класу
    internal abstract partial class Product
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public decimal TotalPrice { get; protected set; }

        protected Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
            TotalPrice = price;
        }

        public abstract void CountTotalPrice(ProductVisitor visitor);
    }
}
