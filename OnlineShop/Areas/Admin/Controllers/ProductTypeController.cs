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
        public async Task<IActionResult> Create(ProductTypes model)
        {
            if (ModelState.IsValid)
            {
                await _db.ProductTypes.AddAsync(model);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // Edit Get Action Method

        public IActionResult Edit(int id)
        {
            if (id > 0)
            {
                var productType = _db.ProductTypes.Find(id);

                if (productType == null)
                {
                    return NotFound();
                }

                return View(productType);
            }

            return NotFound();

        }

        // Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes model)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Update(model);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // Details Action Method
        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                var productType = _db.ProductTypes.Find(id);

                if (productType == null)
                {
                    return NotFound();
                }

                return View(productType);
            }

            return NotFound();

        }

        // Delete Get Action Method

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var productType = _db.ProductTypes.Find(id);

                if (productType == null)
                {
                    return NotFound();
                }

                return View(productType);
            }

            return NotFound();

        }

        // Delete Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductTypes model)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Remove(model);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


    }
}
