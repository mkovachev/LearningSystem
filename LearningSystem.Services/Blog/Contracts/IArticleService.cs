using System.Threading.Tasks;

namespace LearningSystem.Services.Blog.Contracts
{
    public interface IArticleService
    {
        Task CreateAsync(string title, string content, string authorId);
    }
}
