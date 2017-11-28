using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AllCoursesServiceModel>> ActiveAsync()
            => await this.db.Courses
                .OrderByDescending(c => c.Id)
                .Where(c => c.StartDate >= DateTime.UtcNow)
                .ProjectTo<AllCoursesServiceModel>()
                .ToListAsync();

        public async Task<CourseDetailsServiceModel> ByIdAsync(int id)
            => await this.db
                .Courses
                .Where(c => c.Id == id)
                .ProjectTo<CourseDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<bool> SignUpStudent(int courseId, string studentId)
        {
            var course = await this.db
                             .Courses
                             .Where(c => c.Id == courseId)
                              .Select(c => new
                              {
                                  c.StartDate,
                                  IsSignedUp = c.Students.Any(s => s.StudentId == studentId)
                              })
                              .FirstOrDefaultAsync();

            if (course == null 
                || course.StartDate < DateTime.UtcNow 
                || course.IsSignedUp)
            {
                return false;
            }

            var student = new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            };

            this.db.Add(student);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsSignedUp(int courseId, string userId)
        {
            return await this.db
                .Courses
                .AnyAsync(c => c.Id == courseId && c.Students.Any(s => s.StudentId == userId));
        }
    }
}
