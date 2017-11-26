using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Services.Admin.Contracts;
using System;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin.Services
{
    class AdminCourseService : IAdminCourseService
    {
        private readonly LearningSystemDbContext db;

        public AdminCourseService(LearningSystemDbContext db) => this.db = db;

        public async Task CreateAsync(string name, string description, DateTime startDate, DateTime endDate, string trainerId)
        {
            var course = new Course
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndtDate = endDate,
                TrainerId = trainerId
            };

            this.db.Add(course);
            await this.db.SaveChangesAsync();
        }
    }
}
