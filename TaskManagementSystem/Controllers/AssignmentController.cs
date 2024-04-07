using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Attribute;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Assignment;

namespace TaskManagementSystem.Controllers
{
    public class AssignmentController : BaseController
    {
        private readonly IAssignmentService assignmentService;
        private readonly IAssigneeService assigneeService;

        public AssignmentController(
            IAssignmentService _assignmentService,
            IAssigneeService _assigneeService)
        {
            assignmentService = _assignmentService;
            assigneeService = _assigneeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllAssignmentsQueryModel query)
        {
            var model = await assignmentService.AllAsync(
                query.Category,
                query.SearchItem,
                query.Sorting,
                query.CurrentPage,
                query.AssignmentsPerPage);

            query.TotalAssignmentsCount = model.TotalAssignmentsCount;
            query.Assignments = model.Assignments;
            query.Categories = await assignmentService.AllCategoriesNamesAsync();
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<AssignmentServiceModel> model;

            if (await assigneeService.ExistsByIdAsync(userId))
            {
                int assigneeId = await assigneeService.GetAssigneeIdAsync(userId) ?? 0;

                model = await assignmentService.AllAssignmentsByAssigneeIdAsync(assigneeId);
            }
            else
            {
                model = await assignmentService.AllAssignmentsByUserId(userId);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await assignmentService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await assignmentService.AssignmentDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [MustBeAssignee]
        public async Task<IActionResult> Add()
        {
            if (await assigneeService.ExistsByIdAsync(User.Id()) == false)
            {
                return RedirectToAction(nameof(AssigneeController.Become), "Assignee");
            }

            var model = new AssignmentFormModel()
            {
                Categories = await assignmentService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAssignee]
        public async Task<IActionResult> Add(AssignmentFormModel model)
        {
            if (await assignmentService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await assignmentService.AllCategoriesAsync();

                return View(model);
            }

            int? assigneeId = await assigneeService.GetAssigneeIdAsync(User.Id());

            int newAssigneeId = await assignmentService.CreateAsync(model, assigneeId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newAssigneeId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new AssignmentFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AssignmentDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Accept(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
