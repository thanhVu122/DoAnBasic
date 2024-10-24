using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bai_ThucHanh.Data;
using Bai_ThucHanh.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bai_ThucHanh.Controllers
{
    public class ProductcsController : Controller
    {
        private readonly Bai_ThucHanhContext _context;

        public ProductcsController(Bai_ThucHanhContext context)
        {
            _context = context;
        }

        // GET: Productcs
        [HttpPost]
        public async Task<IActionResult> Index(int catid, string keywords)
        {
            var bai_ThucHanhContext = _context.Productcs.Include(p => p.Category).
                Where(p => p.Name.
                Contains(keywords) && p.CategoryId == catid);
            return View(await bai_ThucHanhContext.ToListAsync());
        }

        // GET: Productcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productcs == null)
            {
                return NotFound();
            }

            var productcs = await _context.Productcs
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productcs == null)
            {
                return NotFound();
            }

            return View(productcs);
        }

        // GET: Productcs/Create
        // Chỉ những người dùng với vai trò "Admin" mới truy cập được action này
        [Authorize (Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        // POST: Productcs/Create
       
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Chỉ những người dùng với vai trò "Admin" mới truy cập được action này
 
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageUrl,Quantily,CategoryId")] Productcs productcs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productcs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", productcs.CategoryId);
            return View(productcs);
        }
        // Chỉ những người dùng với vai trò "Admin" mới truy cập được action này
        [Authorize(Roles = "admin")]
        // GET: Productcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productcs == null)
            {
                return NotFound();
            }

            var productcs = await _context.Productcs.FindAsync(id);
            if (productcs == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", productcs.CategoryId);
            return View(productcs);
        }

        // POST: Productcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Chỉ những người dùng với vai trò "Admin" mới truy cập được action này
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl,Quantily,CategoryId")] Productcs productcs)
        {
            if (id != productcs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productcs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductcsExists(productcs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", productcs.CategoryId);
            return View(productcs);
        }

        // GET: Productcs/Delete/5
        // Chỉ những người dùng với vai trò "Admin" mới truy cập được action này
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productcs == null)
            {
                return NotFound();
            }

            var productcs = await _context.Productcs
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productcs == null)
            {
                return NotFound();
            }

            return View(productcs);
        }
        // Chỉ những người dùng với vai trò "Admin" mới truy cập được action này
        [Authorize(Roles = "admin")]
        // POST: Productcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productcs == null)
            {
                return Problem("Entity set 'Bai_ThucHanhContext.Productcs'  is null.");
            }
            var productcs = await _context.Productcs.FindAsync(id);
            if (productcs != null)
            {
                _context.Productcs.Remove(productcs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductcsExists(int id)
        {
            return (_context.Productcs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
