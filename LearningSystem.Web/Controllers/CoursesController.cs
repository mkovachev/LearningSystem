using LearningSystem.Data.Models;
using LearningSystem.Services;
using LearningSystem.Web.Infrastructure.Extensions;
using LearningSystem.Web.Models.CoursesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningSystem.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courses;
        private readonly UserManager<User> userManager;

        public CoursesController(ICourseService courses, UserManager<User> userManager)
        {
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new CourseDetailsViewModel
            {
                Course = await this.courses.ByIdAsync(id)
            };

            if (model.Course == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                var userId = this.userManager.GetUserId(User);
                model.IsSignedUp = await this.courses.UserIsSignedUpAsync(id, userId);
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignUp(int id)
        {
            var studentId = this.userManager.GetUserId(User);
            var success = await courses.SignUpStudentAsync(id, studentId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("You have succesfully singed up for this course");
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOut(int id)
        {
            var studentId = this.userManager.GetUserId(User);
            var success = await courses.SignOutStudentAsync(id, studentId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("You have succesfully singed out");
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
