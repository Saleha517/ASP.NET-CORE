using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "User , Admin")]
        public IActionResult Index()
        {
            return Content("Only User and Admin can access this page ");
        }
    }
}
