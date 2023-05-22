using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    internal interface IChef
    {
        IChef SetNextChef(IChef handler);
        void DoOrder(Order order);
    }
}
