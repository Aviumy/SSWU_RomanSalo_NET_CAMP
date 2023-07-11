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
