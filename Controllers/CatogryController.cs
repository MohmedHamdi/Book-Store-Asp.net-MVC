using bookstore1.Models.Data;
using bookstore1.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookstore1.Controllers
{
    [Authorize]
    public class CatogryController : Controller
    {
        private readonly AppDbContext _context;
        public CatogryController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        
        public IActionResult Index()
        {
            IEnumerable<Catogry> catogries=_context.catogries.ToList();
            return View(catogries);
        }
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult New(Catogry catogry)
        {
                if(catogry == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Add(catogry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Edit(int id)
        {
            var x=_context.catogries.FirstOrDefault(x=>x.CatogryId == id);
            if (x == null)
            {
                return NotFound();
            }
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Edit(Catogry catogry)
        {
            if (ModelState.IsValid)
            {
                _context.Update(catogry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }









        [HttpGet]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Delet(int id)
        {
            var x = _context.catogries.FirstOrDefault(x => x.CatogryId == id);
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delet(Catogry catogry)
        {
            if (ModelState.IsValid)
            {
                _context.Remove(catogry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
