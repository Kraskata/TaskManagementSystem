using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Core.Contracts;

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
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }


    }
}