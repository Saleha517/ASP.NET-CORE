using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using

namespace Class_10.Controllers
{
    public class Mailing : Controller
    {
        // GET: Mailing
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mailing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mailing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mailing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Mailing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mailing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Mailing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mailing/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
