﻿using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Services;
using LearningSystem.Web.Infrastructure;
using LearningSystem.Web.Models.StudentsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningSystem.Web.Controllers
{
    [Authorize(Roles = WebConstants.TrainerRole)]
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainers;
        private readonly UserManager<User> userManager;
        private readonly ICourseService courses;

        public TrainerController(ITrainerService trainers, UserManager<User> userManager, ICourseService courses)
        {
            this.trainers = trainers;
            this.userManager = userManager;
            this.courses = courses;
        }

        public async Task<IActionResult> Courses()
        {
            var trainerId = this.userManager.GetUserId(User);
            var courses = await this.trainers.CoursesAsync(trainerId);

            return View(courses);
        }

        public async Task<IActionResult> Students(int id)
        {
            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return NotFound();
            }

            return View(new StudentInCourseViewModel
            {
                Students = await this.trainers.GetStudentsInCourseAsync(id),
                Course = await this.courses.ByIdAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditGrade(int id, string studentId, Grade grade)
        {
            if (studentId == null)
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return BadRequest();
            }

            var success = await this.trainers.EditGrade(id, studentId, grade);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Students), new { id });
        }
    }
}