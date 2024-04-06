﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Core.Models.Assignment;

namespace TaskManagementSystem.Controllers
{
    [Authorize]
    public class AssignmentController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllAssignmentsQueryModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllAssignmentsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new AssignmentDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AssignmentFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new AssignmentFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, AssignmentFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new AssignmentDetailsViewModel();
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