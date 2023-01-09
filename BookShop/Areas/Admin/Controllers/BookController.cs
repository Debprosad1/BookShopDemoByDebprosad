using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private ApplicationDbContext _db;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _he;

        public BookController(ApplicationDbContext db, Microsoft.AspNetCore.Hosting.IHostingEnvironment he) 
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            //return View(_db.ABook.Include(c=>c.ABookTypes).ToList());
            return View(_db.ABook.Include(c => c.BookTypes).ToList());

        }

        //Post method for Index
        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var products = _db.ABook.Include(c => c.BookTypes)
                .Where(c => c.Price >= lowAmount && c.Price <= largeAmount).ToList();
            if (lowAmount == null || largeAmount == null)
            {
                products = _db.ABook.Include(c => c.BookTypes).ToList();
            }
            return View(products);
        }

        //Get Create method
        public IActionResult Create()
        {
            ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
            //ViewData["TagId"] = new SelectList(_db.SpecialTags.ToList(), "Id", "Name");
            return View();
        }

        //Post Create method
        [HttpPost]
        public async Task<IActionResult> Create(CBook cBook, IFormFile image)
        {
            //if (ModelState.IsValid)
            //{
            var searchProduct = _db.ABook.FirstOrDefault(c => c.Name == cBook.Name);
            if (searchProduct != null)
            {
                ViewBag.message = "This product is already exist";
                ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
                return View(cBook);
            }

            ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
            if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    cBook.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    //cBook.Image = "Images/noimage";
                    cBook.Image = "Images/Deb.jpg";
                }
                _db.ABook.Add(cBook);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        //}
        //    return View(cBook);

    }


        //Get Edit method 

        public IActionResult Edit(int? id)
        {
            ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
            //ViewData["TagId"] = new SelectList(_db.SpecialTags.ToList(), "Id", "Name");
            var Book = _db.ABook.Include(c => c.BookTypes).FirstOrDefault(c => c.Id == id);
            return View(Book);
        }

        //Post Edit method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(CBook cBook, IFormFile image)
        {
            //if (ModelState.IsValid)
            //{
                //var searchProduct = _db.ABook.FirstOrDefault(c => c.Name == cBook.Name);
                //if (searchProduct != null)
                //{
                //    ViewBag.message = "This product is already exist";
                //    ViewData["productTypeId"] = new SelectList(_db.ABook.ToList(), "Id", "ProductType");
                //    return View(cBook);
                //}

            ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
            if (image != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                await image.CopyToAsync(new FileStream(name, FileMode.Create));
                cBook.Image = "Images/" + image.FileName;
            }

            if (image == null)
            {
                cBook.Image = "Images/noimage.PNG";
            }
            _db.Update(cBook);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //return View(cBook);

        }

        //Get Details method 

        public IActionResult Details(int? id)
        {
            ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
            //ViewData["TagId"] = new SelectList(_db.SpecialTags.ToList(), "Id", "Name");
            var Book = _db.ABook.Include(c => c.BookTypes).FirstOrDefault(c => c.Id == id);
            return View(Book);
        }

        //Post Details method
        [HttpPost]
        public  IActionResult Details(CBook cBook, IFormFile image)
        {
            //if (ModelState.IsValid)
            //{
            //var searchProduct = _db.ABook.FirstOrDefault(c => c.Name == cBook.Name);
            //if (searchProduct != null)
            //{
            //    ViewBag.message = "This product is already exist";
            //    ViewData["productTypeId"] = new SelectList(_db.ABook.ToList(), "Id", "ProductType");
            //    return View(cBook);
            //}

            //ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
            //if (image != null)
            //{
            //    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
            //    await image.CopyToAsync(new FileStream(name, FileMode.Create));
            //    cBook.Image = "Images/" + image.FileName;
            //}

            //if (image == null)
            //{
            //    cBook.Image = "Images/noimage.PNG";
            //}
            //_db.Update(cBook);
            //await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //    return View(cBook);

        }

        //Get Delete method 

        public IActionResult Delete(int? id)
        {
            ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
            //ViewData["TagId"] = new SelectList(_db.SpecialTags.ToList(), "Id", "Name");
            var Book = _db.ABook.Include(c => c.BookTypes).FirstOrDefault(c => c.Id == id);
            return View(Book);
        }

        //Post Edit method
        [HttpPost]
        public async Task<IActionResult> Delete(CBook cBook, IFormFile image)
        {
            //if (ModelState.IsValid)
            //{
                //var searchProduct = _db.ABook.FirstOrDefault(c => c.Name == cBook.Name);
                //if (searchProduct != null)
                //{
                //    ViewBag.message = "This product is already exist";
                //    ViewData["productTypeId"] = new SelectList(_db.ABook.ToList(), "Id", "ProductType");
                //    return View(cBook);
                //}

            ViewData["BookTypeId"] = new SelectList(_db.ABookTypes.ToList(), "Id", "BookTypes");
            if (image != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                await image.CopyToAsync(new FileStream(name, FileMode.Create));
                cBook.Image = "Images/" + image.FileName;
            }

            if (image == null)
            {
                cBook.Image = "Images/noimage.PNG";
            }
            _db.Remove(cBook);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //return View(cBook);

        }
    }
}
