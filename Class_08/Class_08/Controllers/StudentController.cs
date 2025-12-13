using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using Class_08.Models;

namespace Class_08.Controllers
{
    public class StudentController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcheck"].ConnectionString;

        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            SqlConnection con = new SqlConnection(cs);
            string query = "Select * from Students";
            SqlCommand queryrun = new SqlCommand(query, con);
            con.Open();
            var fetch = queryrun.ExecuteReader();

            while (fetch.Read())
            {

                students.Add(new Student
                {
                    Id = Convert.ToInt32(fetch["id"]),
                    Name = fetch["name"].ToString(),
                    Age = Convert.ToInt32(fetch["age"]),
                    Address = fetch["stdaddress"].ToString()
                });
            }

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student std)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "Insert into Students (name , age , stdaddress) values (@Name , @Age , @Address)";
                SqlCommand queryRun = new SqlCommand(query, con);
                queryRun.Parameters.AddWithValue("@Name", std.Name);
                queryRun.Parameters.AddWithValue("@Age", std.Age);
                queryRun.Parameters.AddWithValue("@Address", std.Address);
                con.Open();
                queryRun.ExecuteNonQuery();
                return RedirectToAction("Create");
            }
            catch (SqlException er)
            {
                ViewBag.error = "Error "+er.Message;
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student std = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "Select * From Students Where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    std = new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),            
                        Name = reader["Name"].ToString(),              
                        Age = Convert.ToInt32(reader["Age"]),        
                        Address = reader["stdaddress"].ToString()    

                    };
                }
            }
            return View(std);
        }


        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student std = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Students WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    std = new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Address = reader["stdAddress"].ToString()
                    };
                }
            }

            if (std == null) return HttpNotFound();
            return View(std);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "DELETE FROM Student WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
