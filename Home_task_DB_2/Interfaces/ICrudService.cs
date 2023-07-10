using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_DB_2.Interfaces
{
    internal interface ICrudService<T>
    {
        void Create(T obj);
        List<T> ReadAll();
        T ReadOne(int id);
        void Update(int id, T withObj);
        void Delete(int id);
        void SaveChanges();
    }
}
