using LearningSystem.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebConstants.AdminRole)]
    public abstract class BaseAdminController : Controller
    {
      
    }
}