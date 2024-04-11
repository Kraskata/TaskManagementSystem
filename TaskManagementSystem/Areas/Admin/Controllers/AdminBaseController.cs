using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TaskManagementSystem.Core.Constants.RoleConstants;

namespace TaskManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
