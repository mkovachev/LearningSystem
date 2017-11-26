using LearningSystem.Common.Mapping;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace LearningSystem.Services.Blog.Models
{
    public class AllArticlesServiceModel : IMapFrom<Article>, ICustomMapping
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }
        `
        [DataType(DataType.Date)]
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        // map Author.UserName from Article
        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Article, AllArticlesServiceModel>()
                .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
