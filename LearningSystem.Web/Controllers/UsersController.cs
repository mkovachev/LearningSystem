using LearningSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        public async Task<IActionResult> Profile(string id)
        {
            var profile = await this.users.ProfileAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }
    }
}