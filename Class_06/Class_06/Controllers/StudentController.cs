using Class_06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_06.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var students = new List<Student>
            {
                new Student {Id = 1 , Name = "Ali" , age = 24},
                new Student {Id = 2 , Name = "Raza" , age = 25},
                new Student {Id = 3 , Name = "Haider" , age = 26} 
                new Student {Id = 1 , Name = "Ali" , age = 24},
                 new Student {Id = 1 , Name = "Minahali" , age = 30},
            };
            return View(students);+
        }



    }      