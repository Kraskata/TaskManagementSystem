using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Attribute;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Assignee;
using static TaskManagementSystem.Core.Constants.MessageConstants;

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
        [NotAnAssignee]
        public IActionResult Become()
        {
            var model = new BecomeAssigneeFormModel();

            return View(model);
        }

        [HttpPost]
        [NotAnAssignee]
        public async Task<IActionResult> Become(BecomeAssigneeFormModel model)
        {
            if (await assigneeService.UserWithPhoneNumberExistAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }

            if (await assigneeService.UserHasAssignmentsAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasAssignments);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await assigneeService.CreateAsync(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(AssignmentController.All), "Assignment");
        }
    }
}
