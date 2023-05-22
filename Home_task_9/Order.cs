using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    internal class Order
    {
        private List<Dish> _dishes;

        public Order(Dictionary<Dish, uint> dishes)
        {
            _dishes = new List<Dish>();
            foreach (var dish in dishes)
            {
                for (int i = 0; i < dish.Value; i++)
                {
                    _dishes.Add(dish.Key);
                }
            }
        }

        public IEnumerator<Dish> GetEnumerator()
        {
            return _dishes.GetEnumerator();
        }

        public void RemoveDish(Dish dish)
        {
            _dishes.Remove(dish);
        }
    }
}
