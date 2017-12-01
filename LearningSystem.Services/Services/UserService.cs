using System.Threading.Tasks;
using LearningSystem.Services.Models;
using LearningSystem.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using LearningSystem.Data.Models;
using System;

namespace LearningSystem.Services.Services
{
    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;
        private readonly IPdfGenerator pdfGenerator;

        public UserService(LearningSystemDbContext db, IPdfGenerator pdfGenerator)
        {
            this.db = db;
            this.pdfGenerator = pdfGenerator;
        }

        public async Task<byte[]> GetPdfCertificate(int courseId, string studentId)
        {
            var studentInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return null;
            }

            var certificateInfo = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new
                {
                    CourseName = c.Name,
                    CourseStartDate = c.StartDate,
                    CourseEndDate = c.EndDate,
                    StudentName = c.Students
                                    .Where(s => s.StudentId == studentId)
                                    .Select(s => s.Student.Name)
                                    .FirstOrDefault(),
                    StudentGrade = c.Students
                                    .Where(s => s.StudentId == studentId)
                                    .Select(s => s.Grade)
                                    .FirstOrDefault(),
                    Trainer = c.Trainer.Name
                })
                .FirstOrDefaultAsync();

            return this.pdfGenerator.GeneratePdfFromHtml(string.Format(ServiceConstants.PdfCertinficateFormat,
                certificateInfo.CourseName,
                certificateInfo.CourseStartDate.ToShortDateString(),
                certificateInfo.CourseEndDate.ToShortDateString(),
                certificateInfo.StudentName,
                certificateInfo.StudentGrade,
                certificateInfo.Trainer,
                DateTime.UtcNow.ToShortDateString()));
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string email)
            => await this.db
                .Users
                .Where(u => u.Email == email)
                .ProjectTo<UserProfileServiceModel>()
                .FirstOrDefaultAsync();
    }
}
