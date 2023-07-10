using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_DB_2.Models
{
    internal class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Middlename { get; set; }
        [Required]
        public string Group { get; set; }

        public virtual List<Coursework> Courseworks { get; set; }

        public Student() { }

        public Student(int studentId, string firstname, string lastname, string middlename, string group)
        {
            StudentId = studentId;
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            Group = group;
        }
    }
}
