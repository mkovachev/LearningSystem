﻿using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
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

        public async Task<IEnumerable<AllCoursesServiceModel>> Active()
            => await this.db.Courses
                .OrderByDescending(c => c.Id)
                .Where(c => c.StartDate >= DateTime.UtcNow)
                .ProjectTo<AllCoursesServiceModel>()
                .ToListAsync();
    }
}
