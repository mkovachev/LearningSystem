﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Data.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TrainerId { get; set; }

        public User Trainer { get; set; }

        public List<StudentCourse> Students { get; set; } = new List<StudentCourse>();

    }
}