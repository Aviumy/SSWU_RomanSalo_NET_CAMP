using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    internal abstract class Chef : IChef
    {
        private IChef _nextChef;

        public string Surname { get; protected set; }
        public bool IsBusy { get; set; }

        public Dish CurrentDish { get; protected set; }
        public uint OrderTimeLeft { get; protected set; }

        protected Chef(string surname)
        {
            Surname = surname;
            IsBusy = false;
            OrderTimeLeft = 0;
        }

        public IChef SetNextChef(IChef chef)
        {
            return _nextChef = chef;
        }

        public virtual void DoOrder(Order order)
        {
            if (_nextChef != null)
            {
                //Console.WriteLine($"PASS | {Surname}: Cannot do order, passing further.");
                _nextChef.DoOrder(order);
            }
            else
            {
                Console.WriteLine($"OVER | {Surname}: Cannot do order, chain is over.");
            }
        }

        public void Pass1Second()
        {
            if (OrderTimeLeft != 0)
            {
                --OrderTimeLeft;
                if (OrderTimeLeft == 0)
                {
                    IsBusy = false;
                    Console.WriteLine($"END | {Surname}: Ended cooking {CurrentDish}");
                    CurrentDish = null;
                }
                else
                {
                    Console.WriteLine($"COOK | {Surname}: Cooking {CurrentDish} ({OrderTimeLeft})");
                }
            }
        }
    }
}
