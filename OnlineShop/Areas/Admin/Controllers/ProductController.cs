using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        //Index Get Action Method
        public IActionResult Index()
        {
            var productList = _db.Products.Include(p => p.ProductTypes).Include(p => p.Tag).ToList();
            return View(productList);
        }


        // Create Get Action Method
        public IActionResult Create()
        {
            return View();
        }


        // Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    var pathName = Path.Combine(_hostEnvironment.WebRootPath + "/images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(pathName, FileMode.Create));
                    product.ImageUrl = "images/"+ image.FileName;
                }
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

    }
}
