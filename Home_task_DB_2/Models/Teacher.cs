using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_DB_2.Models
{
    internal class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Middlename { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Cathedra { get; set; }

        public virtual List<Coursework> Courseworks { get; set; }

        public Teacher() { }

        public Teacher(string firstname, string lastname, string middlename, string position, string cathedra)
        {
            TeacherId = 0;
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            Position = position;
            Cathedra = cathedra;
        }

        public Teacher(int teacherId, string firstname, string lastname, string middlename, string position, string cathedra)
        {
            TeacherId = teacherId;
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            Position = position;
            Cathedra = cathedra;
        }

        public override string ToString()
        {
            return $"[{TeacherId}] {Position} {Lastname} {Firstname} {Middlename}: кафедра {Cathedra}";
        }
    }
}
