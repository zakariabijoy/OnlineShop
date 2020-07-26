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
    public class TagController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TagController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var tagList = _db.Tags.ToList();
            return View(tagList);
        }

        // Create Get Action Method

        public IActionResult Create()
        {
            return View();
        }

        // Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag model)
        {
            if (ModelState.IsValid)
            {
                await _db.Tags.AddAsync(model);
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
                var tag = _db.Tags.Find(id);

                if (tag == null)
                {
                    return NotFound();
                }

                return View(tag);
            }

            return NotFound();

        }

        // Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Tag model)
        {
            if (ModelState.IsValid)
            {
                _db.Tags.Update(model);
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
                var tag = _db.Tags.Find(id);

                if (tag == null)
                {
                    return NotFound();
                }

                return View(tag);
            }

            return NotFound();

        }

        // Delete Get Action Method

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var tag = _db.Tags.Find(id);

                if (tag == null)
                {
                    return NotFound();
                }

                return View(tag);
            }

            return NotFound();

        }

        // Delete Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Tag model)
        {
            if (ModelState.IsValid)
            {
                _db.Tags.Remove(model);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
