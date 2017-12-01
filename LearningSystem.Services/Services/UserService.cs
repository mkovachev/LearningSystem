using System.Threading.Tasks;
using LearningSystem.Services.Models;
using LearningSystem.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using LearningSystem.Data.Models;

namespace LearningSystem.Services.Services
{
    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;

        public UserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<byte[]> GetPdfCertificate(int courseId, string studentId)
        {
            var studentInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return null;
            }

            var data = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new
                {
                    CourseName = c.Name,
                    CourseStartDate = c.StartDate,
                    CourseEndtDate = c.EndDate,
                    StudentName = c.Students
                    .Where(s => s.StudentId == studentId)
                    .Select(s => s.Student.Name),
                    StudentGrade = c.Students
                    .Where(s => s.StudentId == studentId)
                    .Select(s => s.Grade),
                    Trainer = c.Trainer.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string email)
            => await this.db
                .Users
                .Where(u => u.Email == email)
                .ProjectTo<UserProfileServiceModel>()
                .FirstOrDefaultAsync();
    }
}
