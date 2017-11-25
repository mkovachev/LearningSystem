using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Services.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace LearningSystem.Services.Admin.Services
{
    public class AdminService
    {
        private readonly LearningSystemDbContext db;

        public AdminService(LearningSystemDbContext db) => this.db = db;

        public IEnumerable<AdminAllUsersServiceModel> GetAll()
        {
            // TODO pagnation
            return this.db
                    .Users
                    .ProjectTo<AdminAllUsersServiceModel>()
                    .ToList();
        }
    }
}
