﻿using System;
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

        public Coursework() { }

        public Coursework(string title, string workType, string subject, DateTime approvalDate, DateTime presentationDate, byte mark, int? teacherId = null, int? studentId = null)
        {
            WorkId = 0;
            Title = title;
            WorkType = workType;
            Subject = subject;
            ApprovalDate = approvalDate;
            PresentationDate = presentationDate;
            Mark = mark;
            TeacherId = teacherId;
            StudentId = studentId;
        }

        public Coursework(int workId, string title, string workType, string subject, DateTime approvalDate, DateTime presentationDate, byte mark, int? teacherId = null, int? studentId = null)
        {
            WorkId = workId;
            Title = title;
            WorkType = workType;
            Subject = subject;
            ApprovalDate = approvalDate;
            PresentationDate = presentationDate;
            Mark = mark;
            TeacherId = teacherId;
            StudentId = studentId;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[{WorkId}] {WorkType} робота з предмету {Subject} на тему '{Title}' ({(Mark != 0 ? $"{Mark} б." : "не здано")})");
            sb.Append($"Затверджено: {ApprovalDate.ToString("yyyy.MM.dd")}, ");
            sb.AppendLine($"Здати: {PresentationDate.ToString("yyyy.MM.dd")}, ");
            sb.AppendLine($"Id виконуючого: {StudentId.ToString() ?? "-"}");
            sb.Append($"Id керівника: {TeacherId.ToString() ?? "-"}");
            return sb.ToString();
        }
    }
}
