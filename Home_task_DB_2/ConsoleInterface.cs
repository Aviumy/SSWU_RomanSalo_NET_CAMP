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
            dynamic serviceObj = ChooseService(service);
            if (serviceObj == null)
            {
                Console.WriteLine("Сталася невідома помилка при виборі сервісу");
                CrudMenu(service);
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Меню додавання об'єкта. Введіть дані:");
            dynamic newObj = null;
            if (service == typeof(StudentService))
            {
                string lastname = ValidateStringFromConsole("Прізвище: ");
                string firstname = ValidateStringFromConsole("Ім'я: ");
                string middlename = ValidateStringFromConsole("По батькові: ");
                string group = ValidateStringFromConsole("Академ. група: ");

                Student student = new Student
                {
                    Lastname = lastname,
                    Firstname = firstname,
                    Middlename = middlename,
                    Group = group
                };
                newObj = student;
            }
            else if (service == typeof(TeacherService))
            {
                string lastname = ValidateStringFromConsole("Прізвище: ");
                string firstname = ValidateStringFromConsole("Ім'я: ");
                string middlename = ValidateStringFromConsole("По батькові: ");
                string position = ValidateStringFromConsole("Посада: ");
                string cathedra = ValidateStringFromConsole("Кафедра: ");

                Teacher teacher = new Teacher
                {
                    Lastname = lastname,
                    Firstname = firstname,
                    Middlename = middlename,
                    Position = position,
                    Cathedra = cathedra,
                };
                newObj = teacher;
            }
            else
            {
                Console.WriteLine("В розробці...");
                MainMenu();
                return;
            }

            Console.WriteLine(newObj);
            Console.WriteLine("Додати цей об'єкт в БД?");
            do
            {
                Console.WriteLine("Натисніть Y для підтвердження, або N для відміни");
                Console.Write(">>> ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (!"yYnN".Contains(input));

            if ("yY".Contains(input))
            {
                try
                {
                    serviceObj.Create(newObj);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Сталася помилка при додаванні в БД");
                    Console.WriteLine(e.Message);
                    CrudMenu(service);
                    return;
                }
                serviceObj.SaveChanges();
                Console.WriteLine("Об'єкт успішно додано");
                CrudMenu(service);
            }
            else
            {
                Console.WriteLine("Відміна, об'єкт не додано");
                CrudMenu(service);
            }
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
            dynamic serviceObj = ChooseService(service);
            if (serviceObj == null)
            {
                Console.WriteLine("Сталася невідома помилка при виборі сервісу");
                CrudMenu(service);
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Меню редагування об'єкта");
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
                dynamic obj = serviceObj?.ReadOne(id);
                if (obj != null)
                {
                    Console.WriteLine(obj);
                    Console.WriteLine("Редагувати цей об'єкт?");
                    do
                    {
                        Console.WriteLine("Натисніть Y для підтвердження, або N для відміни");
                        Console.Write(">>> ");
                        input = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                    } while (!"yYnN".Contains(input));

                    if ("yY".Contains(input))
                    {
                        dynamic editedObj = null;
                        if (obj is Student)
                        {
                            string lastname = ValidateStringFromConsole("Прізвище: ");
                            string firstname = ValidateStringFromConsole("Ім'я: ");
                            string middlename = ValidateStringFromConsole("По батькові: ");
                            string group = ValidateStringFromConsole("Академ. група: ");

                            Student student = new Student
                            {
                                StudentId = obj.StudentId,
                                Lastname = lastname,
                                Firstname = firstname,
                                Middlename = middlename,
                                Group = group
                            };
                            editedObj = student;
                        }
                        else if (obj is Teacher)
                        {
                            string lastname = ValidateStringFromConsole("Прізвище: ");
                            string firstname = ValidateStringFromConsole("Ім'я: ");
                            string middlename = ValidateStringFromConsole("По батькові: ");
                            string position = ValidateStringFromConsole("Посада: ");
                            string cathedra = ValidateStringFromConsole("Кафедра: ");

                            Teacher teacher = new Teacher
                            {
                                TeacherId = obj.TeacherId,
                                Lastname = lastname,
                                Firstname = firstname,
                                Middlename = middlename,
                                Position = position,
                                Cathedra = cathedra,
                            };
                            editedObj = teacher;
                        }
                        else
                        {
                            Console.WriteLine("В розробці...");
                            MainMenu();
                            return;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Старий об'єкт:");
                        Console.WriteLine(obj);
                        Console.WriteLine("Новий об'єкт:");
                        Console.WriteLine(editedObj);
                        Console.WriteLine("Прийняти зміни?");
                        do
                        {
                            Console.WriteLine("Натисніть Y для підтвердження, або N для відміни");
                            Console.Write(">>> ");
                            input = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                        } while (!"yYnN".Contains(input));

                        if ("yY".Contains(input))
                        {
                            try
                            {
                                serviceObj.Update(id, editedObj);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Сталася помилка при редагуванні");
                                Console.WriteLine(e.Message);
                                UpdateMenu(service);
                                return;
                            }
                            serviceObj.SaveChanges();
                            Console.WriteLine("Об'єкт успішно відредаговано");
                            UpdateMenu(service);
                        }
                        else
                        {
                            Console.WriteLine("Відміна, об'єкт не змінено");
                            UpdateMenu(service);
                        }
                    }
                    else
                    {
                        UpdateMenu(service);
                    }
                }
                else
                {
                    Console.WriteLine("Результат за таким id не знайдено");
                    UpdateMenu(service);
                }
            }
            else
            {
                Console.WriteLine("Не вдалось конвертувати ввід в число. Введіть ціле число");
                UpdateMenu(service);
            }
        }

        private void DeleteMenu(Type service)
        {
            dynamic serviceObj = ChooseService(service);
            if (serviceObj == null)
            {
                Console.WriteLine("Сталася невідома помилка при виборі сервісу");
                CrudMenu(service);
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Меню видалення одного об'єкта");
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
                dynamic result = serviceObj?.ReadOne(id);

                if (result != null)
                {
                    Console.WriteLine(result);
                    Console.WriteLine("Видалити цей об'єкт?");
                    Console.WriteLine("Натисніть лат. x для підтвердження, або будь-яку іншу кнопку для відміни");
                    Console.Write(">>> ");
                    input = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if ("xX".Contains(input))
                    {
                        try
                        {
                            serviceObj.Delete(id);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Сталася помилка при видаленні з БД");
                            Console.WriteLine(e.Message);
                            DeleteMenu(service);
                            return;
                        }
                        serviceObj.SaveChanges();
                        Console.WriteLine("Об'єкт видалено");
                        DeleteMenu(service);
                    }
                    else
                    {
                        Console.WriteLine("Відміна, об'єкт залишено");
                        DeleteMenu(service);
                    }
                }
                else
                {
                    Console.WriteLine("Результат за таким id не знайдено");
                    DeleteMenu(service);
                }
            }
            else
            {
                Console.WriteLine("Не вдалось конвертувати ввід в число. Введіть ціле число");
                DeleteMenu(service);
            }
        }

        private void CourseworkInfoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Який запит вивести?");
            Console.WriteLine("1 - Роботи, які ще не здані");
            Console.WriteLine("2 - Роботи, які 4-курсники здавали минулого року");
            Console.WriteLine("3 - Студенти, які здали хоча б одну роботу не на відмінно");
            Console.WriteLine("4 - Список зданих робіт, з іменами студентів та їх керівників");
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
            else if (input == '4')
            {
                courseworkInfoService.CourseworksWithStudentsAndTeachersNames().ForEach(Console.WriteLine);
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

        private dynamic ChooseService(Type service)
        {
            dynamic serviceObj = null;
            if (service == typeof(StudentService))
            {
                serviceObj = studentService;
            }
            else if (service == typeof(TeacherService))
            {
                serviceObj = teacherService;
            }
            else if (service == typeof(CourseworkService))
            {
                serviceObj = courseworkService;
            }
            return serviceObj;
        }

        private string ValidateStringFromConsole(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine().Trim();
            while (input == string.Empty)
            {
                Console.WriteLine("Не можна вводити пустий рядок");
                Console.Write(message);
                input = Console.ReadLine().Trim();
            }
            return input;
        }
    }
}
