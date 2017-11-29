using LearningSystem.Services.Models;
using System.Collections.Generic;

namespace LearningSystem.Web.Models.StudentsViewModels
{
    public class StudentInCourseViewModel
    {
        public IEnumerable<StudentInCourseServiceModel> Students { get; set; }

        public CourseDetailsServiceModel Course { get; set; }
    }
}
