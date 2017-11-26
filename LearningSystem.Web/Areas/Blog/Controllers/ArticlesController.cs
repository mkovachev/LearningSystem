using LearningSystem.Services.Html.Contracts;
using LearningSystem.Web.Areas.Blog.Models.Articles;
using LearningSystem.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
    [Area("Blog")]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService html;

        public ArticlesController(IHtmlService html)
        {
            this.html = html;
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



            return RedirectToAction(nameof(Index));
        }
    }
}