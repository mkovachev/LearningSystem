using System;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin.Contracts
{
    public interface IAdminCourseService
    {
        // for void async method  = replace void with Task!

        Task CreateAsync(
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            string trainerId
            );
    }
}
