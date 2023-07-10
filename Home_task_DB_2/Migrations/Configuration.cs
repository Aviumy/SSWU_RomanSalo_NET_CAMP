namespace Home_task_DB_2.Migrations
{
    using Home_task_DB_2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Home_task_DB_2.Persistence.UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Home_task_DB_2.Persistence.UniversityDbContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
            }

            Student[] students = new Student[]
            {
                new Student(1, "Роман", "Сало", "Олегович", "ФЕІ-31"),
                new Student(2, "Олег", "Кузьма", "Андрійович", "ФЕІ-31"),
                new Student(3, "Віталій", "Ярема", "Андрійович", "ФЕІ-31"),
                new Student(4, "Олена", "Прокопова", "Максимівна", "ФЕІ-32"),
                new Student(5, "Віктор", "Туз", "Романович", "ФЕІ-32"),
                new Student(6, "Руслан", "Степанчук", "Степанович", "ФЕІ-41"),
                new Student(7, "Олексій", "Ростовий", "Степанович", "ФЕІ-41"),
                new Student(8, "Василина", "Парасюк", "Олегівна", "ФЕІ-42"),
                new Student(9, "Ольга", "Парандій", "Олегівна", "ФЕІ-42"),
                new Student(10, "Андрій", "Орел", "Андрійович", "ФЕІ-51"),
                new Student(11, "Максим", "Червоний", "Андрійович", "ФЕІ-51"),
            };
            foreach (var student in students)
            {
                context.Students.AddOrUpdate(student);
            }

            Teacher[] teachers = new Teacher[]
            {
                new Teacher(1, "Олег", "Кушнір", "Вікторович", "проф.", "штучного інтелекту"),
                new Teacher(2, "Степан", "Ольжич", "Вікторович", "доц.", "штучного інтелекту"),
                new Teacher(3, "Віталій", "Рудий", "Вікторович", "доц.", "штучного інтелекту"),
                new Teacher(4, "Руслан", "Манджур", "Вікторович", "ас.", "штучного інтелекту"),
                new Teacher(5, "Богдана", "Сас", "Стефанівна", "проф.", "радіофізики та КТ"),
                new Teacher(6, "Олег", "Коваль", "Олегович", "доц.", "радіофізики та КТ"),
                new Teacher(7, "Василь", "Кушнір", "Олегович", "доц.", "радіофізики та КТ"),
                new Teacher(8, "Стефан", "Коваленко", "Олексійович", "ас.", "радіофізики та КТ"),
            };
            foreach (var teacher in teachers)
            {
                context.Teachers.AddOrUpdate(teacher);
            }

            Coursework[] courseworks = new Coursework[]
            {
                new Coursework(1, "Проектування розподіленої системи ШІ", "Курсова", "Системи штучного інтелекту", new DateTime(2023, 2, 27), new DateTime(2023, 6, 2), 0, 1, 1),
                new Coursework(2, "Алгоритми пошуку в іграх", "Курсова", "Системи штучного інтелекту", new DateTime(2023, 2, 27), new DateTime(2023, 6, 2), 0, 1, 2),
                new Coursework(3, "Дослідження глибоких нейромереж", "Курсова", "Системи штучного інтелекту", new DateTime(2023, 2, 27), new DateTime(2023, 6, 2), 0, 2, null),
                new Coursework(4, "Бібліотеки Python для МН", "Курсова", "Системи штучного інтелекту", new DateTime(2023, 2, 27), new DateTime(2023, 6, 2), 0, 2, null),
                new Coursework(5, "Проект з використанням OpenCV", "Курсова", "Системи штучного інтелекту", new DateTime(2023, 2, 27), new DateTime(2023, 6, 2), 0, 3, 3),
                new Coursework(6, "Фільтри Калмана", "Курсова", "Системи штучного інтелекту", new DateTime(2023, 2, 27), new DateTime(2023, 6, 2), 0, 4, null),
                new Coursework(7, "Удосконалення програми для роботи з графами", "Курсова", "Алгоритми і структури даних", new DateTime(2023, 2, 27), new DateTime(2023, 6, 3), 0, 5, 4),
                new Coursework(8, "Написання бібліотеки для алгоритмів пошуку", "Курсова", "Алгоритми і структури даних", new DateTime(2023, 2, 27), new DateTime(2023, 6, 3), 0, 6, 5),
                
                new Coursework(9, "Проект 'Розпізнавання зображень'", "Бакалаврська", "Машинне навчання", new DateTime(2023, 3, 5), new DateTime(2023, 6, 14), 0, 1, 6),
                new Coursework(10, "Обробка прородних текстів", "Бакалаврська", "Машинне навчання", new DateTime(2023, 3, 5), new DateTime(2023, 6, 14), 0, 3, 7),
                new Coursework(11, "Рекурентні нейронні мережі", "Бакалаврська", "Машинне навчання", new DateTime(2023, 3, 5), new DateTime(2023, 6, 14), 0, 3, null),
                new Coursework(12, "Система керуванням БПЛА", "Бакалаврська", "Вбудовані системи", new DateTime(2023, 3, 5), new DateTime(2023, 6, 12), 0, 6, null),
                new Coursework(13, "Реалізація системи відслідковування руху", "Бакалаврська", "Вбудовані системи", new DateTime(2023, 3, 5), new DateTime(2023, 6, 12), 0, 7, 9),

                new Coursework(14, "Покращення системи пошуку зображень", "Курсова", "Системи штучного інтелекту", new DateTime(2022, 2, 25), new DateTime(2022, 5, 31), 95, 1, 6),
                new Coursework(15, "Експертні системи", "Курсова", "Системи штучного інтелекту", new DateTime(2022, 2, 25), new DateTime(2022, 5, 31), 92, 2, 7),
                new Coursework(16, "Реалізація алгоритму Дейкстри для різних задач", "Курсова", "Алгоритми і структури даних", new DateTime(2022, 2, 25), new DateTime(2022, 5, 31), 96, 5, 8),
                new Coursework(17, "Структури даних в С++", "Курсова", "Алгоритми і структури даних", new DateTime(2022, 2, 25), new DateTime(2022, 5, 31), 81, 8, 9),
                
                new Coursework(18, "Розробка системи комп'ютерного зору", "Бакалаврська", "Машинне навчання", new DateTime(2022, 3, 3), new DateTime(2022, 6, 17), 91, 2, 10),
                new Coursework(19, "Додаток для аналізу ринку", "Бакалаврська", "Машинне навчання", new DateTime(2022, 3, 3), new DateTime(2022, 6, 17), 94, 3, 11),
            };
            foreach (var coursework in courseworks)
            {
                context.Courseworks.AddOrUpdate(coursework);
            }

            context.SaveChanges();
        }
    }
}
