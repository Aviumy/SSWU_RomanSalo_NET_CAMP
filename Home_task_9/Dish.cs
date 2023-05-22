using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    internal enum Category
    {
        pizza,
        dessert,
        drink,
    }

    internal class Dish
    {
        public string Name { get; private set; }
        public uint CookingTime { get; private set; }
        public Category Category { get; private set; }

        public Dish(string name, uint cookingTime, Category category)
        {
            Name = name;
            CookingTime = cookingTime;
            Category = category;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
