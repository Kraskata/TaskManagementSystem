using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementSystem.Core.Contracts.Assignment;
using TaskManagementSystem.Core.Models.Home;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class HomeController : Controller
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

        public async Task<IActionResult> Index()
        {
            var model = await assignmentService.NewestThreeAssignments();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}