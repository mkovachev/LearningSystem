using LearningSystem.Data.Models;
using LearningSystem.Services.Admin;
using LearningSystem.Web.Areas.Admin.Models.Users;
using LearningSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    public class UsersController : BaseAdminController
    {
        private readonly IAdminService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(IAdminService users, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.users.GetAllAsync();
            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();


            return View(new AdminAllUsersViewModel
            {
                Users = users,
                Roles = roles
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddtoRole(AddUserToRoleViewModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);

            if (user == null || !roleExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            if (!await userManager.IsInRoleAsync(user, model.Role))
            {
                TempData.AddErrorMessage($"{user.UserName} has already a {model.Role} role.");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await this.userManager.AddToRoleAsync(user, model.Role);

                TempData.AddSuccessMessage($"User {user.UserName} successfully added to role {model.Role}.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}