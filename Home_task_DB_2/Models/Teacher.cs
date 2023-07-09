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
    }
}
