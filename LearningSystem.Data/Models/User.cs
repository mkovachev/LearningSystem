using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LearningSystem.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<StudentCourse> Courses { get; set; }
    }
}
