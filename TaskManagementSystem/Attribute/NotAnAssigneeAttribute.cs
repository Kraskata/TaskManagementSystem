using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Attribute
{
    public class NotAnAssigneeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IAssigneeService? assigneeService = context.HttpContext.RequestServices.GetService<IAssigneeService>();

            if (assigneeService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (assigneeService != null && 
                assigneeService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
