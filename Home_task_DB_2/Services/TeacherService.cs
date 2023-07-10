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
    internal class TeacherService : ICrudService<Teacher>
    {
        private UniversityDbContext _context;

        public TeacherService(UniversityDbContext context)
        {
            _context = context;
        }

        public void Create(Teacher obj)
        {
            _context.Teachers.Add(obj);
        }

        public void Delete(int id)
        {
            var teacher = ReadOne(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
            }
        }

        public List<Teacher> ReadAll()
        {
            return _context.Teachers.ToList();
        }

        public Teacher ReadOne(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void Update(int id, Teacher withObj)
        {
            var teacher = ReadOne(id);
            if (teacher != null)
            {
                _context.Entry(teacher).CurrentValues.SetValues(withObj);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
