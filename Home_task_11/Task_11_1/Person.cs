using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11_1
{
    internal class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public uint Age { get; set; }

        public int CompareTo(Person? other)
        {
            if (this.Age < other.Age)
            {
                return -1;
            }
            else if (this.Age == other.Age)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
