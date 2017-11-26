﻿using LearningSystem.Data.Models;
using LearningSystem.Services.Blog.Contracts;
using LearningSystem.Services.Html.Contracts;
using LearningSystem.Web.Areas.Blog.Models.Articles;
using LearningSystem.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
    [Area("Blog")]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService html;
        private readonly IArticleService articles;
        private readonly UserManager<User> userManager;


        public ArticlesController(IHtmlService html, IArticleService articles, UserManager<User> userManager)
        {
            this.html = html;
            this.articles = articles;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index() => View();

        public async Task<IActionResult> Create() => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);

            var authorId = this.userManager.GetUserId(User);


            await this.articles.CreateAsync(
                model.Title,
                model.Content,
                authorId
                );

            return RedirectToAction(nameof(Index));
        }
    }
}