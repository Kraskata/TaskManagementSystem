using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }

        public IActionResult ForReview()
        {
            return View();
        }
    }
}
