using bookstore1.Models.Data;
using bookstore1.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace bookstore1.Controllers
{


    [Authorize]
    public class AuthorController : Controller
    {
        private readonly AppDbContext  _context;
      
        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Author> Auth = _context.Authors.ToList();
            return View(Auth);
        }
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult New(Author author)
        {
            if(author == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                return  RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Edit(int id)
        {
            var x= _context.Authors.SingleOrDefault(x=>x.AuthorId==id);
            if(x==null)
            {
                return NotFound();
            }
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Edit(Author author)
        {
           
            if (ModelState.IsValid)
            {
               _context.Update(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Delet(int id)
        {
            var x = _context.Authors.SingleOrDefault(x => x.AuthorId == id);
            if (x == null)
            {
                return NotFound();
            }
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Delet(Author author)
        {

            if (ModelState.IsValid)
            {
                _context.Remove(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }






    }
}
