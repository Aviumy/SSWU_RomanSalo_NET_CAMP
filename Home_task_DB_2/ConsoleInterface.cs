using Home_task_DB_2.Persistence;
using Home_task_DB_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_DB_2
{
    internal class ConsoleInterface
    {
        UniversityDbContext context;

        StudentService studentService;
        TeacherService teacherService;
        CourseworkService courseworkService;
        CourseworkInfoService courseworkInfoService;

        char input;

        public ConsoleInterface()
        {
            context = new UniversityDbContext();

            studentService = new StudentService(context);
            teacherService = new TeacherService(context);
            courseworkService = new CourseworkService(context);
            courseworkInfoService = new CourseworkInfoService(context);

            input = ' ';
        }

        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("З чим працюватимемо?");
            Console.WriteLine("1 - Студенти");
            Console.WriteLine("2 - Викладачі");
            Console.WriteLine("3 - Курсові роботи");
            Console.WriteLine("4 - Складні запити інформації");
            Console.WriteLine("0 - Вихід");
            Console.Write(">>> ");

            input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (input == '1')
            {
                CrudMenu(typeof(StudentService));
            }
            else if (input == '2')
            {
                CrudMenu(typeof(TeacherService));
            }
            else if (input == '3')
            {
                CrudMenu(typeof(CourseworkService));
            }
            else if (input == '4')
            {
                CourseworkInfoMenu();
            }
            else if (input == '0')
            {
                Console.WriteLine("Виходимо...");
                return;
            }
            else
            {
                Console.WriteLine("Неправильний ввід! Спробуйте ще раз");
                MainMenu();
            }
        }

        private void CrudMenu(Type service)
        {

        }

        private void CreateMenu(Type service)
        {

        }

        private void ReadAllMenu(Type service)
        {

        }

        private void ReadOneMenu(Type service)
        {

        }

        private void UpdateMenu(Type service)
        {

        }

        private void DeleteMenu(Type service)
        {

        }

        private void CourseworkInfoMenu()
        {

        }
    }
}
