﻿using AutoMapper;
using LearningSystem.Common.Mapping;
using LearningSystem.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LearningSystem.Services.Models
{
    public class UserProfileServiceModel : IMapFrom<User>, ICustomMapping
    {
        public string Email { get; set; }

        public IEnumerable<UserProfileCourseServiceModel> Courses { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<User, UserProfileServiceModel>()
                .ForMember(u => u.Courses, cfg => cfg.MapFrom(s => s.Courses.Select(c => c.Course)));
        }
    }
}
