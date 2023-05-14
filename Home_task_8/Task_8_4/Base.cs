using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_4
{
    internal class Base
    {
        protected int number;
        public event Action SomeEvent;

        public Base(int number = 0)
        {
            this.number = number;
        }

        public virtual void DoSomething()
        {
            if (number < 10)
            {
                InvokeSomeEvent();
            }
        }

        protected void InvokeSomeEvent()
        {
            SomeEvent?.Invoke();
        }
    }
}
