using LearningSystem.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<AllCoursesServiceModel>> ActiveAsync();

        Task<CourseDetailsServiceModel> ByIdAsync(int id);

        Task<bool> UserIsSignedUpAsync(int courseId, string studentId);

        Task<bool> SignUpStudentAsync(int courseId, string studentId);

        Task<bool> SignOutStudentAsync(int courseId, string studentId);

        Task<IEnumerable<AllCoursesServiceModel>> FindAsync(string search);

    }
}
