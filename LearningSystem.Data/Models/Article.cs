﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
