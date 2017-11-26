using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Services.Admin.Contracts;
using LearningSystem.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin.Services
{
    public class AdminService : IAdminService
    {
        private readonly LearningSystemDbContext db;

        public AdminService(LearningSystemDbContext db) => this.db = db;

        public async Task<IEnumerable<AdminAllUsersServiceModel>> GetAllAsync()  // TODO pagnation
            => await this.db
                 .Users
                 .ProjectTo<AdminAllUsersServiceModel>()
                 .ToListAsync();
    }
}
