using LearningSystem.Data.Models;
using LearningSystem.Services.Admin.Contracts;
using LearningSystem.Web.Areas.Admin.Models.Courses;
using LearningSystem.Web.Infrastructure;
using LearningSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    public class CoursesController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdminCourseService courses;

        public CoursesController(UserManager<User> userManager, IAdminCourseService courses)
        {
            this.userManager = userManager;
            this.courses = courses;
        }

        public async Task<IActionResult> Create()
            => View(new CreateCourseViewModel
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1),
                Trainers = await this.GetTrainersAsync()
            });

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Trainers = await this.GetTrainersAsync();
                return View(model);
            }

            await this.courses.CreateAsync(
                model.Name,
                model.Description,
                model.StartDate,
                model.EndDate,
                model.TrainerId
                );

            TempData.AddSuccessMessage($"Course {model.Name} created successfully!");

            return Redirect("/");

            // Variant 2
            // redirect format: (nameof(action, controller)
            // return RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty });
        }

        private async Task<IEnumerable<SelectListItem>> GetTrainersAsync()
        {
            var trainers = await this.userManager.GetUsersInRoleAsync(WebConstants.TrainerRole);

            var trainersList = trainers.Select(t => new SelectListItem
            {
                Value = t.Id,
                Text = t.UserName
            })
            .ToList();

            return trainersList;
        }
    }
}