using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Assignee;
using TaskManagementSystem.Extentions;

namespace TaskManagementSystem.Controllers
{
    public class AssigneeController : BaseController
    {
        private readonly IAssigneeService assigneeService;

        public AssigneeController(IAssigneeService _assigneeService)
        {
            assigneeService = _assigneeService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await assigneeService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }



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
