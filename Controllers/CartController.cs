using bookstore1.Models.Data;
using bookstore1.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace bookstore1.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext appDbContext)
        {
            _context = appDbContext; 
        }
        [Authorize]
        public IActionResult All()
        {

            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<Cart> carts = _context.carts.ToList();
                decimal y = 0;
                foreach (var x in carts)
                {
                    y = y + x.total;
                }
                ViewBag.y = y;

                return View(carts);
            }
            else
            {
                DeletAll();
                var cart = _context.carts.ToList();
               
              return View(cart);
            }
           
               
         
        }
        public IActionResult Index(int id)
        {
            var x = _context.books.FirstOrDefault(e => e.BookId == id);
            if (x != null)
            {
                Cart cart = new Cart();
                cart.price = x.Price;
                cart.Titel = x.Title;
                cart.BookId = x.BookId;
                return View(cart);

            }
            else
            {
                return NotFound();
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Cart cart)
       {
           var x=cart.price*cart.count;
            Console.WriteLine(x);
            cart.total = x;
            Console.WriteLine(cart.BookId);
            Console.WriteLine(cart.BookId);
            var x1 = cart;
            if (ModelState.IsValid)
            {
                _context.carts.Add(cart);
                _context.SaveChanges();
                return RedirectToAction("All");

            }
            else
            {
                return NotFound();
            }



        }


        public IActionResult Edit(int id)
        {
         var x=   _context.carts.FirstOrDefault(e=>e.CartId==id);
            if (x != null)
            {
                return View(x);
            }
            else { return NotFound(); }
           
        }
        [HttpPost][ValidateAntiForgeryToken]
        public IActionResult Edit(Cart cart)
        {
            if(cart!=null)
            {
               
                cart.total = cart.price * cart.count;

            }

            if (ModelState.IsValid)
            {
             _context.carts.Update(cart);
                _context.SaveChanges();
                return RedirectToAction("All");
            }
            else { return NotFound(); }

        }



        public IActionResult Delet(int id)
        {
            var x = _context.carts.FirstOrDefault(e => e.CartId == id);
            if (x != null)
            {
                return View(x);
            }
            else { return NotFound(); }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delet(Cart cart)
        {
           

            if (ModelState.IsValid)
            {
                _context.carts.Remove(cart);
                _context.SaveChanges();
                return RedirectToAction("All");
            }
            else { return NotFound(); }

        }


    public void DeletAll()
        {
            foreach(var cart in _context.carts)
            {
                _context.Remove(cart);
                _context.SaveChanges();
            }
        }







    }
}
