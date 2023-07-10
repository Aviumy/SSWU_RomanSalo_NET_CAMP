using Home_task_DB_2.Models;
using Home_task_DB_2.Persistence;
using Home_task_DB_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_DB_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            UniversityDbContext context = new UniversityDbContext();

            StudentService studentService = new StudentService(context);
            TeacherService teacherService = new TeacherService(context);
            CourseworkService courseworkService = new CourseworkService(context);
            CourseworkInfoService courseworkInfoService = new CourseworkInfoService(context);

            TestStudents();
            TestCourseworkInfoService();

            Console.ReadKey();

            void TestStudents()
            {
                // Read
                studentService.ReadAll().ForEach(Console.WriteLine);
                Console.WriteLine(studentService.ReadOne(1));

                // Create
                Student newStudent = new Student("A", "B", "C", "XXX-15");
                Student newStudent2 = new Student("X", "Y", "Z", "XXX-46");
                studentService.Create(newStudent);
                studentService.Create(newStudent2);
                studentService.SaveChanges();
                Console.WriteLine($"\nAdded:");
                studentService.ReadAll().ForEach(Console.WriteLine);
                Console.ReadKey();

                // Update
                var studToUpd = studentService.ReadAll().Last();
                studToUpd.Firstname = "XXXXXXX";
                studentService.Update(studToUpd.StudentId, studToUpd);
                studentService.SaveChanges();
                Console.WriteLine($"\nUpdated:");
                studentService.ReadAll().ForEach(Console.WriteLine);
                Console.ReadKey();

                // Delete
                int lastId = studentService.ReadAll().Last().StudentId;
                studentService.Delete(lastId - 1);
                studentService.Delete(lastId);
                studentService.Delete(999);
                studentService.SaveChanges();
                Console.WriteLine($"\nDeleted:");
                studentService.ReadAll().ForEach(Console.WriteLine);
                Console.ReadKey();
            }

            void TestCourseworkInfoService()
            {
                Console.WriteLine("Query 1");
                var q1 = courseworkInfoService.AllUnpresentedCourseworks();
                q1.ForEach(Console.WriteLine);
                Console.WriteLine();

                Console.WriteLine("Query 2");
                var q2 = courseworkInfoService.LastYearCourseworksOf4GradeStudents();
                q2.ForEach(Console.WriteLine);
                Console.WriteLine();

                Console.WriteLine("Query 3");
                var q3 = courseworkInfoService.StudentsWithLessThan90Mark();
                q3.ForEach(Console.WriteLine);
                Console.WriteLine();
            }
        }
    }
}
