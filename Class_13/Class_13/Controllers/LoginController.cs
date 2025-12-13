using Microsoft.AspNetCore.Mvc;
using Class_13.Models;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace Class_13.Controllers
{
    public class LoginController : Controller
    {
        //string cs = "Data Source = STUDENTS; Integrated Security = True; Encrypt = False";

        private readonly IConfiguration configuration;
        private readonly string con;

        public LoginController(IConfiguration configuration)
        {
            configuration = configuration;
            con = configuration.GetConnectionString("dbcon");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(user u)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "Insert into Users (username , password) values ( @username , @password)";
                SqlCommand queryRun = new SqlCommand(query, con);
                queryRun.Parameters.AddWithValue("@username", u.username);
                queryRun.Parameters.AddWithValue("@password", u.password);

                con.Open();

                queryRun.ExecuteNonQuery();

                return RedirectToAction("Create");


            }

            catch (Exception ex) {
            
                ViewBag.ErrorMessage = ex.Message;
                return View();
            
            }


        }
    }
}
