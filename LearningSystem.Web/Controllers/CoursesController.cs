using LearningSystem.Services;
using LearningSystem.Web.Models.CoursesViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningSystem.Web.Controllers
{
    public class CoursesController: Controller
    {
        private readonly ICourseService courses;

        public CoursesController(ICourseService courses)
        {
            this.courses = courses;
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await this.courses.DetailsAsync(id);

            return View(new CourseDetailsViewModel
            {

            });
        }
    }
}
