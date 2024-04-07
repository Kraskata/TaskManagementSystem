using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Home;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAssignmentService assignmentService;

        public HomeController(
            ILogger<HomeController> logger,
            IAssignmentService _assignmentService)
        {
            _logger = logger;
            assignmentService = _assignmentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await assignmentService.NewestFourAssignmentsAsync();

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}