using LearningSystem.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Controllers
{
    [Authorize(Roles = WebConstants.TrainerRole)]
    public class TrainerController : Controller
    {
        public IActionResult Courses()
        {
            return View();
        }
    }
}