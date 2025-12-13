using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class EditorController : Controller
    {

        [Authorize(Roles = "Editor , Admin")]
        public IActionResult Index()
        {
            return Content("Only Editor and Admin can see this");
        }
    }
}
