using LearningSystem.Services.Models;
using System.Collections.Generic;

namespace LearningSystem.Web.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<AllCoursesServiceModel> Courses { get; set; }

        public string Search { get; set; }
    }
}
