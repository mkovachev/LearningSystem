using LearningSystem.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<AllCoursesServiceModel>> ActiveAsync();

        Task<CourseDetailsServiceModel> ByIdAsync (int id);

        Task<bool> UserIsSignedInCourse(int courseId, string userId);


    }
}
