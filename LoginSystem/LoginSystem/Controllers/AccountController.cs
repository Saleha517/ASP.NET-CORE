using LoginSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using System.Security.Claims;

namespace LoginSystem.Controllers
{
    public class AccountController : Controller
    {
        public string cs = "Data Source=STUDENTS;Initial Catalog=LoginSystem;Integrated Security=True;Encrypt=False";

        public IActionResult Register()
        {
            return View();
        }

        //Get 

        public IActionResult Login()
        {
            return View();
        }

        //Post
        [HttpPost]

        public IActionResult Login(LoginViewModel model)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "SELECT Username,Role from Users where Username = @u AND Password =@p";
            SqlCommand queryRun = new SqlCommand(query, con);
            queryRun.Parameters.AddWithValue("@u", model.Username);
            queryRun.Parameters.AddWithValue("@p", model.Password);

            SqlDataReader row = queryRun.ExecuteReader();

            if(row.Read())
            {
                string role = row["role"].ToString();

                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , model.Username),
                    new Claim(ClaimTypes.Role , role)
                };

                var identity = new ClaimsIdentity(claim , "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync("CookieAuth", principal);

                return RedirectToAction("Dashboard", "Admin");

            }

            ViewBag.Error = "Invaid Credentials!";
                return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");

        }
    }
}
