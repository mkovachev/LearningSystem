﻿using AutoMapper;
using LearningSystem.Common.Mapping;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using System.Linq;

namespace LearningSystem.Services.Models
{
    public class StudentInCourseServiceModel : IMapFrom<User>, ICustomMapping
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public Grade Grade { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            int courseId = default(int);
            mapper
                 .CreateMap<User, StudentInCourseServiceModel>()
                 .ForMember(s => s.Grade, cfg => cfg.MapFrom(u => u
                 .Courses.Where(c => c.CourseId == courseId)
                 .Select(c => c.Grade)
                 .FirstOrDefault()));
        }
    }
}
