using LearningSystem.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    public class CreateArticleViewModel
    {
        [Required]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

    }
}
