using Home_task_DB_2.Models;
using Home_task_DB_2.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Home_task_DB_2.Services
{
    internal class CourseworkInfoService
    {
        private UniversityDbContext _context;

        public CourseworkInfoService(UniversityDbContext context)
        {
            _context = context;
        }

        // Виведення всіх робіт, які ще не здані
        public List<Coursework> AllUnpresentedCourseworks()
        {
            var now = new DateTime(2023, 5, 1);
            var query = _context.Courseworks
                .Where(c => c.PresentationDate > now);

            return query.ToList();
        }

        // Виведення робіт, які 4-курсники здавали минулого року
        public List<Coursework> LastYearCourseworksOf4GradeStudents()
        {
            var studentIds = _context.Students.ToList()
                .Where(s => Regex.IsMatch(s.Group, @"4\d"))
                .Select(s => s.StudentId);
            var query = _context.Courseworks
                .Where(
                    c => c.PresentationDate.Year == DateTime.Now.Year - 1 &&
                    studentIds.Contains((int)c.StudentId)
                );

            return query.ToList();
        }

        // Виведення всіх студентів, які здали хоча б одну роботу менше ніж на 90 балів
        public List<Student> StudentsWithLessThan90Mark()
        {
            var now = new DateTime(2023, 5, 1);
            var works = _context.Courseworks
                .Where(c => c.Mark < 90 && c.PresentationDate < now);
            var query = _context.Students
                .Where(
                    s => works.Select(c => c.StudentId)
                    .Contains(s.StudentId)
                );

            return query.ToList();
        }
    }
}
