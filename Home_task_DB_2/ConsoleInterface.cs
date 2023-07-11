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
            string serviceName = "'невідомий'";
            if (service == typeof(StudentService))
            {
                serviceName = "студентів";
            }
            else if (service == typeof(TeacherService))
            {
                serviceName = "викладачів";
            }
            else if (service == typeof(CourseworkService))
            {
                serviceName = "курсових робіт";
            }

            Console.WriteLine();
            Console.WriteLine($"Вибрано сервіс {serviceName}. Яку дію виконати?");
            Console.WriteLine("1 - Створити");
            Console.WriteLine("2 - Прочитати все");
            Console.WriteLine("3 - Прочитати одне");
            Console.WriteLine("4 - Змінити");
            Console.WriteLine("5 - Видалити");
            Console.WriteLine("0 - Назад");
            Console.Write(">>> ");

            input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (input == '1')
            {
                CreateMenu(service);
            }
            else if (input == '2')
            {
                ReadAllMenu(service);
            }
            else if (input == '3')
            {
                ReadOneMenu(service);
            }
            else if (input == '4')
            {
                UpdateMenu(service);
            }
            else if (input == '5')
            {
                DeleteMenu(service);
            }
            else if (input == '0')
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Неправильний ввід! Спробуйте ще раз");
                CrudMenu(service);
            }
        }

        private void CreateMenu(Type service)
        {

        }

        private void ReadAllMenu(Type service)
        {
            if (service == typeof(StudentService))
            {
                studentService.ReadAll().ForEach(Console.WriteLine);
            }
            else if (service == typeof(TeacherService))
            {
                teacherService.ReadAll().ForEach(Console.WriteLine);
            }
            else if (service == typeof(CourseworkService))
            {
                courseworkService.ReadAll().ForEach(Console.WriteLine);
            }
            CrudMenu(service);
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
