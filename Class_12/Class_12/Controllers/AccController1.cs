using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Class_12.Models;

namespace Class_12.Controllers
{
    public class AccController1 : Controller
    {

        public List<LoginModel> users = new List<LoginModel> {

          new LoginModel{Username = "admin" , Password = "12345" }
        };
        public IActionResult Index()
        {
            return View();
        }

        //post

        [HttpPost]

        public IActionResult Index(string username, string password)
        {
            var user = users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                return View("Index");
            }

            HttpContext.Session.SetString("Username", username);

            return RedirectToAction("Dashboard", "Home");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
