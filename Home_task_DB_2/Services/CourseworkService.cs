using Home_task_DB_2.Interfaces;
using Home_task_DB_2.Models;
using Home_task_DB_2.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_DB_2.Services
{
    internal class CourseworkService : ICrudService<Coursework>
    {
        private UniversityDbContext _context;

        public CourseworkService(UniversityDbContext context)
        {
            _context = context;
        }

        public void Create(Coursework obj)
        {
            _context.Courseworks.Add(obj);
        }

        public void Delete(int id)
        {
            var coursework = ReadOne(id);
            if (coursework != null)
            {
                _context.Courseworks.Remove(coursework);
            }
        }

        public List<Coursework> ReadAll()
        {
            return _context.Courseworks.ToList();
        }

        public Coursework ReadOne(int id)
        {
            return _context.Courseworks.Find(id);
        }

        public void Update(int id, Coursework withObj)
        {
            var coursework = ReadOne(id);
            if (coursework != null)
            {
                _context.Entry(coursework).CurrentValues.SetValues(withObj);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
