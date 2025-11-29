using System.Diagnostics;
using Class_11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Class_11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {


            HttpContext.Session.SetString("Username", "Saleha");

            HttpContext.Session.SetInt32("Id" , 10);

            return View();
        }

        public IActionResult About()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Clear();

            ViewBag.user = HttpContext.Session.GetString("Username");

            ViewBag.userid = HttpContext.Session.GetInt32("Id");

           

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
