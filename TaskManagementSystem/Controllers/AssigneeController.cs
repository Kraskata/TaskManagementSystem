using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Core.Models.Assignee;

namespace TaskManagementSystem.Controllers
{
    [Authorize]
    public class AssigneeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var model = new BecomeAssigneeFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAssigneeFormModel model)
        {
            return RedirectToAction(nameof(AssignmentController.All));
        }
    }
}
