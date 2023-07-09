using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_DB_2.Models
{
    internal class Coursework
    {
        [Key]
        public int WorkId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string WorkType { get; set; }
        [Required]
        public string Subject { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime PresentationDate { get; set; }
        public byte Mark { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
