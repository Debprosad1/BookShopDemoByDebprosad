using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookTypesController : Controller
    {
        private ApplicationDbContext _db;
        public BookTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ABookTypes.ToList());
        }

        //Get method for Create
        public ActionResult Create()
        {
            return View();
        }

        //Post method for Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CBookTypes bookTypesObj)
        {
            if (ModelState.IsValid)
            {
                _db.ABookTypes.Add(bookTypesObj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bookTypesObj);
        }


        //Get method for Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var BookType = _db.ABookTypes.Find(id);
            if (BookType == null)
            {
                return NotFound();
            }
            return View(BookType);
        }

        //Post method for Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CBookTypes bookTypesObj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(bookTypesObj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bookTypesObj);
        }


        //Get method for Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var BookType = _db.ABookTypes.Find(id);
            if (BookType == null)
            {
                return NotFound();
            }
            return View(BookType);
        }

        //Post method for Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Details(CBookTypes bookTypesObj)
        {
            if (ModelState.IsValid)
            {
   
                return RedirectToAction("Index");
            }
            return View(bookTypesObj);
        }


        //Get method for Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var BookType = _db.ABookTypes.Find(id);
            if (BookType == null)
            {
                return NotFound();
            }
            return View(BookType);
        }

        //Post method for Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CBookTypes bookTypesObj)
        {
            if (ModelState.IsValid)
            {
                _db.Remove(bookTypesObj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bookTypesObj);
        }

    }

}