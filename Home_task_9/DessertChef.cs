using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    internal class DessertChef : Chef
    {
        public DessertChef(string surname) : base(surname)
        {
        }

        public override void DoOrder(Order order)
        {
            if (!IsBusy)
            {
                foreach (var dish in order)
                {
                    if (dish.Category == Category.dessert)
                    {
                        order.RemoveDish(dish);
                        CurrentDish = dish;
                        IsBusy = true;
                        OrderTimeLeft = dish.CookingTime;
                        Console.WriteLine($"RUN | {Surname}: Started cooking {dish} ({CurrentDish.CookingTime})");
                        break;
                    }
                }
                base.DoOrder(order);
            }
            else
            {
                base.DoOrder(order);
            }
        }
    }
}
