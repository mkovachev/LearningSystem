using System;
using System.Collections.Generic;

namespace LearningSystem.Data.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Trainer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndtDate { get; set; }

        public IEnumerable<StudentCourse> Students { get; set; }
    }
}