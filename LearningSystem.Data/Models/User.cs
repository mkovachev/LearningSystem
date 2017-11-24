using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LearningSystem.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<Course> Trainings { get; set; } = new List<Course>();

        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}
