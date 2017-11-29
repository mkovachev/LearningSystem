﻿using LearningSystem.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services
{
    public interface ITrainerService
    {
        Task<IEnumerable<CourseDetailsServiceModel>> CoursesAsync(string trainerId);

        Task<IEnumerable<StudentInCourseServiceModel>> GetStudentsInCourseAsync(int courseId);

        Task<bool> IsTrainer(int courseId, string trainerId);

    }
}
