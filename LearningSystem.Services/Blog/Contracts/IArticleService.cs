using LearningSystem.Services.Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services.Blog.Contracts
{
    public interface IArticleService
    {
        Task CreateAsync(string title, string content, string authorId);

        Task<IEnumerable<AllArticlesServiceModel>> GetAllAsync(int page = 1);

        Task<int> GetTotalAsync();
    }
}
