using LearningSystem.Services.Admin.Models;
using System.Collections.Generic;

namespace LearningSystem.Services.Admin
{
    public interface IAdminService
    {
        IEnumerable<AdminAllUsersServiceModel> GetAll();
    }
}
