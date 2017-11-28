using LearningSystem.Services.Models;

namespace LearningSystem.Web.Models.CoursesViewModels
{
    public class CourseDetailsViewModel
    {

        public CourseDetailsServiceModel Course { get; set; }

        public bool? UserIsSignedInCourse { get; set; } // nullable: if not logged is null

    }
}
