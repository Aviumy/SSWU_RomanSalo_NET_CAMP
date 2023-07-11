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
            Console.WriteLine();
            Console.WriteLine("Отримання одного об'єкта");
            Console.WriteLine("Введіть id об'єкта (ціле число) і натисність Enter");
            Console.WriteLine("Щоб вийти, просто натисніть Enter без вводу");
            Console.Write(">>> ");
            string idInput = Console.ReadLine().Trim();
            if (idInput == string.Empty)
            {
                CrudMenu(service);
                return;
            }

            int id;
            if (int.TryParse(idInput, out id))
            {
                dynamic result = null;
                if (service == typeof(StudentService))
                {
                    result = studentService.ReadOne(id);
                }
                else if (service == typeof(TeacherService))
                {
                    result = teacherService.ReadOne(id);
                }
                else if (service == typeof(CourseworkService))
                {
                    result = courseworkService.ReadOne(id);
                }
                Console.WriteLine(result ?? "Результат за таким id не знайдено");
                ReadOneMenu(service);
            }
            else
            {
                Console.WriteLine("Не вдалось конвертувати ввід в число. Введіть ціле число");
                ReadOneMenu(service);
            }
        }

        private void UpdateMenu(Type service)
        {

        }

        private void DeleteMenu(Type service)
        {

        }

        private void CourseworkInfoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Який запит вивести?");
            Console.WriteLine("1 - Роботи, які ще не здані");
            Console.WriteLine("2 - Роботи, які 4-курсники здавали минулого року");
            Console.WriteLine("3 - Студенти, які здали хоча б одну роботу не на відмінно");
            Console.WriteLine("0 - Назад");
            Console.Write(">>> ");

            input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (input == '1')
            {
                courseworkInfoService.AllUnpresentedCourseworks().ForEach(Console.WriteLine);
                CourseworkInfoMenu();
            }
            else if (input == '2')
            {
                courseworkInfoService.LastYearCourseworksOf4GradeStudents().ForEach(Console.WriteLine);
                CourseworkInfoMenu();
            }
            else if (input == '3')
            {
                courseworkInfoService.StudentsWithLessThan90Mark().ForEach(Console.WriteLine);
                CourseworkInfoMenu();
            }
            else if (input == '0')
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Неправильний ввід! Спробуйте ще раз");
                Console.WriteLine();
                CourseworkInfoMenu();
            }
        }
    }
}
