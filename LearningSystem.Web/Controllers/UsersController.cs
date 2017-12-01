using LearningSystem.Data.Models;
using LearningSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService users;
        private readonly UserManager<User> userManager;

        public UsersController(IUserService users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Profile(string id)
        {
            var profile = await this.users.ProfileAsync(id); // id = email

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        [Authorize]
        public async Task<IActionResult> DownloadCertificate(int id)
        {
            var studentId = this.userManager.GetUserId(User);
            var certificate = await this.users.GetPdfCertificate(id, studentId);

            if (certificate == null)
            {
                return BadRequest();
            }

            return File(certificate, "application/pdf", "Certificate.pdf");
        }
    }
}