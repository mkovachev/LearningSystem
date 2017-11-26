using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace LearningSystem.Web.Infrastructure.Filters
{
    /// <summary>
    /// This action filter validates the model state, if action is model
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var controller = context.Controller as Controller;

                var model = context
                    .ActionArguments
                    .FirstOrDefault(a => a.Key.ToLower().Contains("model"))
                    .Value;
                // Variat 2 var model = context.ActionArguments["model"];

                if (controller == null || model == null)
                {
                    return;
                }

                context.Result = controller.View();
            }
        }

    }
}
