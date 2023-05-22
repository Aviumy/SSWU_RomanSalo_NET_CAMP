using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    internal class Simulator
    {
        private uint _time;
        private List<Chef> _chefs;
        private List<Order> _orders;

        public Simulator(List<Chef> chefs, List<Order> orders)
        {
            _time = 0;
            _chefs = chefs;
            _orders = orders;

            for (int i = 0; i < _chefs.Count - 1; i++)
            {
                _chefs[i].SetNextChef(_chefs[i + 1]);
            }
        }

        public void Simulate1Second()
        {
            foreach (var order in _orders)
            {
                _chefs[0].DoOrder(order);
            }
            _time++;
            foreach (var chef in _chefs)
            {
                chef.Pass1Second();
            }
        }
    }
}
