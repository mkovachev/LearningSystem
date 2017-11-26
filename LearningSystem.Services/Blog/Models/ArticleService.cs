using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Services.Blog.Contracts;
using System;
using System.Threading.Tasks;

namespace LearningSystem.Services.Blog.Models
{
    public class ArticleService : IArticleService
    {
        private readonly LearningSystemDbContext db;

        public ArticleService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title, string content, string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            this.db.Add(article);
            await this.db.SaveChangesAsync();
        }
    }
}
