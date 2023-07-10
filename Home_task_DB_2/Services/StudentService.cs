using Home_task_DB_2.Interfaces;
using Home_task_DB_2.Models;
using Home_task_DB_2.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_DB_2.Services
{
    internal class StudentService : ICrudService<Student>
    {
        private UniversityDbContext _context;

        public StudentService(UniversityDbContext context)
        {
            _context = context;
        }

        public void Create(Student obj)
        {
            _context.Students.Add(obj);
        }

        public void Delete(int id)
        {
            var student = ReadOne(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public List<Student> ReadAll()
        {
            return _context.Students.ToList();
        }

        public Student ReadOne(int id)
        {
            return _context.Students.Find(id);
        }

        public void Update(int id, Student withObj)
        {
            var student = ReadOne(id);
            if (student != null)
            {
                _context.Entry(student).CurrentValues.SetValues(withObj);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
