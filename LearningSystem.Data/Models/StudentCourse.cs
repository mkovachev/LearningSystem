﻿using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Data.Models
{
    public class StudentCourse
    {
        public string StudentId { get; set; }

        public User Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public Grade? Grade { get; set; }

        [MaxLength(2 * 1024)]
        public byte[] ExamSubmission { get; set; }
    }

}
