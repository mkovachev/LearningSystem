using LearningSystem.Services;
using LearningSystem.Web.Models;
using LearningSystem.Web.Models.Home;
using LearningSystem.Web.Models.HomeViewModels;
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

        public async Task<IActionResult> Search(HomeIndexViewModel model)
            => View(new SearchViewModel
            {
                Search = model.Search,
                Courses = await this.courses.FindAsync(model.Search)
            });

        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
