using LearningSystem.Services.Models;
using System.Collections.Generic;

namespace LearningSystem.Web.Models.HomeViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<AllCoursesServiceModel> Courses { get; set; } = new List<AllCoursesServiceModel>();

        public string Search { get; set; }
    }
}
