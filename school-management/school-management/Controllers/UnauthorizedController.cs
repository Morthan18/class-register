using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace school_management.Controllers
{
    public class UnauthorizedController : Controller
    {
        // GET: UnauthorizedController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UnauthorizedController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnauthorizedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnauthorizedController/Create
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

        // GET: UnauthorizedController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnauthorizedController/Edit/5
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

        // GET: UnauthorizedController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnauthorizedController/Delete/5
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
