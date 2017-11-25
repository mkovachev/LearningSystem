using System.Threading.Tasks;

namespace LearningSystem.Services.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
