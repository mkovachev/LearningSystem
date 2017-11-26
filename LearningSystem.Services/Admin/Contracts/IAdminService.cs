using LearningSystem.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminAllUsersServiceModel>> GetAllAsync();
    }
}
