using AutoMapper;
using LearningSystem.Common.Mapping;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using System.Linq;

namespace LearningSystem.Services.Models
{
    public class UserProfileCourseServiceModel : IMapFrom<Course>, ICustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade? Grade { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            string studentId = null;
            mapper
                .CreateMap<Course, UserProfileCourseServiceModel>()
                .ForMember(c => c.Grade, cfg => cfg
                    .MapFrom(c => c.Students
                        .Where(s => s.StudentId == studentId)
                        .Select(s => s.Grade)
                        .FirstOrDefault()));
        }
    }
}
