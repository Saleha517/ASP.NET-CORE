using System.Diagnostics;
using Class_10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace Class_10.Controllers
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
            try
            {
                MailMessage mail = new MailMessage();

                mail.To.Add("salehausman517@gmail.com");

                mail.From = new MailAddress("salehausman517@gmail.com");

                mail.Subject = "Asp.Net MVC Core Mailer";

                mail.Body = "<h1>ASP.NET Mailer Here</h1>";

                mail.IsBodyHtml = true;

                mail.ReplyTo = new MailAddress("xyz@gmail.com");

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("salehausman517@gmail.com" , "cuig vwwp gyni xpwz");

                smtp.Send(mail);

            }
            catch (Exception ex) { 

                  ViewBag.Message = ex.Message;
            }
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
