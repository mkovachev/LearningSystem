using LearningSystem.Common.Mapping;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace LearningSystem.Services.Blog.Models
{
    public class ArticleDetailsServiceModel : IMapFrom<Article>, ICustomMapping
    {
        [Required]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Article, ArticleDetailsServiceModel>()
                .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
        }
    }
}
