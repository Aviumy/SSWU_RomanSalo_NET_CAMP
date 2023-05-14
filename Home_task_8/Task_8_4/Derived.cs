using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_4
{
    internal class Derived : Base
    {
        public Derived(int number = 0) 
            : base(number)
        {

        }

        public override void DoSomething()
        {
            if (number > 10)
            {
                // CS0070: The event 'Base.SomeEvent' can only appear on the left hand side of += or -= (except when used from within the type 'Base')
                // Тобто ми не можемо напряму викликати подію батьківського класу у дочірньому класі
                //SomeEvent?.Invoke();

                // Рішення - створити у батьківському класі метод, який обгортає виклик події, і викликати його у дочірньому класі
                InvokeSomeEvent();
            }
        }
    }
}
