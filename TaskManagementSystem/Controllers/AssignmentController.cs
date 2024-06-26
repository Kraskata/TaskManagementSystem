﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Attribute;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Exceptions;
using TaskManagementSystem.Core.Extentions;
using TaskManagementSystem.Core.Models.Assignment;

namespace TaskManagementSystem.Controllers
{
    public class AssignmentController : BaseController
    {
        private readonly IAssignmentService assignmentService;

        private readonly IAssigneeService assigneeService;

        private readonly ILogger logger;

        public AssignmentController(
            IAssignmentService _assignmentService,
            IAssigneeService _assigneeService,
            ILogger<AssignmentController> _logger)
        {
            assignmentService = _assignmentService;
            assigneeService = _assigneeService;
            logger = _logger;
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
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await assignmentService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await assignmentService.AssignmentDetailsByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        [MustBeAssignee]
        public async Task<IActionResult> Add()
        {
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
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await assignmentService.AllCategoriesAsync();

                return View(model);
            }

            int? assigneeId = await assigneeService.GetAssigneeIdAsync(User.Id());

            int newAssigneeId = await assignmentService.CreateAsync(model, assigneeId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newAssigneeId, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await assignmentService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await assignmentService.HasAssigneeWithIdAsync(id, User.Id()) &&
                !User.IsAdmin())
            {
                return Unauthorized();
            }

            var model = await assignmentService.GetAssignmentFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AssignmentFormModel model)
        {
            if (!await assignmentService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await assignmentService.HasAssigneeWithIdAsync(id, User.Id()) &&
                !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await assignmentService.CategoryExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await assignmentService.AllCategoriesAsync();

                return View(model);
            }

            await assignmentService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await assignmentService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await assignmentService.HasAssigneeWithIdAsync(id, User.Id()) == false &&
                !User.IsAdmin())
            {
                return Unauthorized();
            }

            var assignment = await assignmentService.AssignmentDetailsByIdAsync(id);

            var model = new AssignmentDetailsViewModel()
            {
                Id = id,
                Description = assignment.Description,
                Title = assignment.Title
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AssignmentDetailsViewModel model)
        {
            if (!await assignmentService.ExistsAsync(model.Id))
            {
                return BadRequest();
            }

            if (!await assignmentService.HasAssigneeWithIdAsync(model.Id, User.Id()) &&
                !User.IsAdmin())
            {
                return Unauthorized();
            }

            await assignmentService.DeleteAsync(model.Id);


            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Accept(int id)
        {
            if (await assignmentService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await assigneeService.ExistsByIdAsync(User.Id()) &&
                !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (await assignmentService.IsAcceptedAsync(id))
            {
                return BadRequest();
            }

            await assignmentService.AcceptAsync(id, User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await assignmentService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            try
            {
                await assignmentService.LeaveAsync(id, User.Id());
            }
            catch (UnauthorizedActionException uae)
            {
                logger.LogError(uae, "AssignmentController/Leave");

                return Unauthorized();
            }


            return RedirectToAction(nameof(Mine));
        }
    }
}
