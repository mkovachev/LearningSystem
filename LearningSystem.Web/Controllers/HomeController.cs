using LearningSystem.Services;
using LearningSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LearningSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courses;

        public HomeController(ICourseService courses)
        {
            this.courses = courses;
            // this.HttpContext.Session; // shopping cart
        }

        public async Task<IActionResult> Index()
            => View(new HomeIndexViewModel
            {
                Courses = await this.courses.ActiveAsync()
            });

        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
