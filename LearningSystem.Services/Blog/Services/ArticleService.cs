using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Services.Blog.Contracts;
using LearningSystem.Services.Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LearningSystem.Services.Blog.Services
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


        public async Task<IEnumerable<AllArticlesServiceModel>> GetAllAsync(int page = 1)
            => await this.db
                   .Articles
                   .OrderByDescending(a => a.PublishDate)
                   .Skip((page - 1) * ServiceConstants.AllArticlesPageSize)
                   .Take(ServiceConstants.AllArticlesPageSize)
                   .ProjectTo<AllArticlesServiceModel>()
                   .ToListAsync();

        public async Task<ArticleDetailsServiceModel> GetByIdAsync(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<int> GetTotalAsync()
            => await this.db.Articles.CountAsync();
    }
}
