using System;
using System.Collections.Generic;

namespace LearningSystem.Data.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndtDate { get; set; }

        public string TrainerId { get; set; }

        public User Trainer { get; set; }

        public List<StudentCourse> Students { get; set; } = new List<StudentCourse>();
    }
}