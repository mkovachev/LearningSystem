using LearningSystem.Services.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LearningSystem.Web.Areas.Admin.Models.Users
{
    public class AdminAllUsersViewModel
    {
        public IEnumerable<AdminAllUsersServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
