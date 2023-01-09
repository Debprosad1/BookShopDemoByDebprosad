using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private ApplicationDbContext _db;
        public HomeController (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ABook.Include(c=>c.BookTypes));
        }

        //GET product detail acation method

        public ActionResult Detail(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.ABook.Include(c => c.BookTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}