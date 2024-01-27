using bookstore1.Models.Data;
using bookstore1.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bookstore1.Controllers
{
    [Authorize]
    public class booksController : Controller
    {
        private readonly AppDbContext _context;
        public booksController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Book>Books=_context.books.ToList();
            return View(Books);
        }
        [HttpGet]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult New()
        {
           
          

            creatList(1);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult New(Book book)
        {
            if(ModelState.IsValid)
            {
                _context.books.Add(book);
                
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
        public IActionResult Edit(int?id) 
        {
            if (id == 0||id==null)
            {
                return NotFound();
            }
          var book= _context.books.FirstOrDefault(x=>x.BookId==id.Value);
            if (book==null)
            {
                return NotFound();
            }
            creatList(id.Value);
            Console.WriteLine(book.Title+"  "+ book.Price+"  "+book.AuthorId);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Edit(Book book)
        {
           if(ModelState.IsValid)
            {
                _context.books.Update(book);
                _context.SaveChanges();
               
                return RedirectToAction("Index");
            }
           else
            return View(book);
        }
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Delet(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var book = _context.books.FirstOrDefault(x => x.BookId == id.Value);
            if (book == null)
            {
                return NotFound();
            }
            creatList(id.Value);
            
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rols.Roladmin)]
        public IActionResult Delet(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.books.Remove(book);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return View(book);
        }









       




        public void creatList(int id=1 )
        {
            //var x1 = _context.catogries.FirstOrDefault(x => x.CatogryName == "select catogry");
            //id = x1.CatogryId;
            List<Catogry> catogries = _context.catogries.ToList();
            SelectList listItems = new SelectList(catogries, "CatogryId", "CatogryName", id);
            ViewBag.ListItems = listItems;
        }

    }
}
