using bookstore1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bookstore1.Controllers
{

   
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}