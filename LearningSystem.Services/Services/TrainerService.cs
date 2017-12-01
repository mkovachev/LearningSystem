using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Services.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;

        public TrainerService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseDetailsServiceModel>> CoursesAsync(string trainerId)
            => await this.db
                .Courses
                .Where(c => c.TrainerId == trainerId)
                .ProjectTo<CourseDetailsServiceModel>()
                .ToListAsync();

        public async Task<bool> IsTrainer(int courseId, string trainerId)
            => await this.db
                .Courses
                .AnyAsync(c => c.Id == courseId && c.TrainerId == trainerId);

        public async Task<IEnumerable<StudentInCourseServiceModel>> GetStudentsInCourseAsync(int courseId)
            => await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .SelectMany(c => c.Students.Select(s => s.Student))
                .ProjectTo<StudentInCourseServiceModel>(new { courseId })
                .ToListAsync();

        public async Task<bool> EditGrade(int courseId, string studentId, Grade grade)
        {
            var stundetInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

            if (stundetInCourse == null)
            {
                return false;
            }

            stundetInCourse.Grade = grade;

            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<byte[]> GetExamSubmissionAsync(int courseId, string studentId)
            => (await this.db
                .FindAsync<StudentCourse>(courseId, studentId))
                ?.ExamSubmission;
    }
}
