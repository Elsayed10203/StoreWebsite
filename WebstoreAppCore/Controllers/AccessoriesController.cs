using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public AccessoriesController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: Accessories
        public async Task<IActionResult> Index()
        {
            var storeWebsiteContext = _context.Accessories.Include(a => a.AccessoryType).Include(a => a.Product);
            return View(await storeWebsiteContext.ToListAsync());
        }

        // GET: Accessories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessories = await _context.Accessories
                .Include(a => a.AccessoryType)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (accessories == null)
            {
                return NotFound();
            }

            return View(accessories);
        }

        // GET: Accessories/Create
        public IActionResult Create()
        {
            ViewData["AccessoryTypeId"] = new SelectList(_context.AccessoryTypes, "AccessoryTypeId", "AccessoryType");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,AccessoryTypeId")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccessoryTypeId"] = new SelectList(_context.AccessoryTypes, "AccessoryTypeId", "AccessoryType", accessories.AccessoryTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", accessories.ProductId);
            return View(accessories);
        }

        // GET: Accessories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessories = await _context.Accessories.FindAsync(id);
            if (accessories == null)
            {
                return NotFound();
            }
            ViewData["AccessoryTypeId"] = new SelectList(_context.AccessoryTypes, "AccessoryTypeId", "AccessoryType", accessories.AccessoryTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", accessories.ProductId);
            return View(accessories);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,AccessoryTypeId")] Accessories accessories)
        {
            if (id != accessories.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessoriesExists(accessories.ProductId))
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
            ViewData["AccessoryTypeId"] = new SelectList(_context.AccessoryTypes, "AccessoryTypeId", "AccessoryType", accessories.AccessoryTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", accessories.ProductId);
            return View(accessories);
        }

        // GET: Accessories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessories = await _context.Accessories
                .Include(a => a.AccessoryType)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (accessories == null)
            {
                return NotFound();
            }

            return View(accessories);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessories = await _context.Accessories.FindAsync(id);
            _context.Accessories.Remove(accessories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessoriesExists(int id)
        {
            return _context.Accessories.Any(e => e.ProductId == id);
        }
    }
}
