﻿using LearningSystem.Services;
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
            // shopping cart
            // this.HttpContext.Session;

            this.courses = courses;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.courses.ActiveAsync());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
