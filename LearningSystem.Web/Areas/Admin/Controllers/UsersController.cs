using LearningSystem.Services.Admin;
using LearningSystem.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace LearningSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebConstants.AdminRole)]
    public class UsersController : Controller
    {
        private readonly IAdminService users;

        public UsersController(IAdminService users) => this.users = users;

        public IActionResult Index() => View(this.users.GetAll());
    }
}