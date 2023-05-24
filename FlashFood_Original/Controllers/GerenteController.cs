using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashFood_Original.Controllers
{
    public class GerenteController : Controller
    {

        private readonly Contexto db;

        public GerenteController(Contexto contexto)
        {
            db = contexto;
        }





        // GET: GerenteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GerenteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GerenteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GerenteController/Create
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

        // GET: GerenteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GerenteController/Edit/5
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

        // GET: GerenteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GerenteController/Delete/5
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
