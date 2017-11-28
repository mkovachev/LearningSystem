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

        public async Task<bool> SignUpStudentAsync(int courseId, string studentId)
        {
            var course = await this.GetCourseInfo(courseId, studentId);

            if (course == null
                || course.StartDate < DateTime.UtcNow
                || course.UserIsSignedUp)
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

        public async Task<bool> SignOutStudentAsync(int courseId, string studentId)
        {

            var course = await this.GetCourseInfo(courseId, studentId);

            if (course == null
                 || course.StartDate < DateTime.UtcNow
                 || !course.UserIsSignedUp)
            {
                return false;
            }

            // make sure ids are in the same order as in db!
            var studentInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

            // Var 2 make join of two tables and should be slower
            // var studentInCourse = await db.Courses
            //    .Where(c => c.Id == courseId)
            //    .SelectMany(c => c.Students)
            //    .FirstOrDefaultAsync(s => s.StudentId == studentId);

            this.db.Remove(studentInCourse);

            await this.db.SaveChangesAsync();

            return true;
        }

        private async Task<CourseWithStudentsServiceModel> GetCourseInfo(int courseId, string studentId)
            => await this.db
                             .Courses
                             .Where(c => c.Id == courseId)
                              .Select(c => new CourseWithStudentsServiceModel
                              {
                                  StartDate = c.StartDate,
                                  UserIsSignedUp = c.Students.Any(s => s.StudentId == studentId)
                              })
                              .FirstOrDefaultAsync();

        public async Task<bool> UserIsSignedUpAsync(int courseId, string studentId)
        {
            return await this.db
                .Courses
                .AnyAsync(c => c.Id == courseId && c.Students.Any(s => s.StudentId == studentId));
        }
    }
}
