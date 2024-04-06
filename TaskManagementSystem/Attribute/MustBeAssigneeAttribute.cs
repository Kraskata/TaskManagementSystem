using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using TaskManagementSystem.Controllers;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Attribute
{
    public class MustBeAssigneeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IAssigneeService? assigneeService = context.HttpContext.RequestServices.GetService<IAssigneeService>();

            if (assigneeService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (assigneeService != null &&
                assigneeService.ExistsByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(AssigneeController.Become), "Assignee", null);
            }
        }
    }
}
