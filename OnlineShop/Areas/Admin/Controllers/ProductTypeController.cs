using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var productTypeList = _db.ProductTypes.ToList();
            return View(productTypeList);
        }

        // Create Get Action Method

        public IActionResult Create()
        {
            return View();
        }

        // Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productType)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
