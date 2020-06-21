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
    public class ProductPictures1Controller : Controller
    {
        private readonly StoreWebsiteContext _context;

        public ProductPictures1Controller(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: ProductPictures1
        public async Task<IActionResult> Index()
        {
            var storeWebsiteContext = _context.ProductPictures.Include(p => p.Product);
            return View(await storeWebsiteContext.ToListAsync());
        }

        // GET: ProductPictures1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPictures = await _context.ProductPictures
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productPictures == null)
            {
                return NotFound();
            }

            return View(productPictures);
        }

        // GET: ProductPictures1/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: ProductPictures1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductImagePath")] ProductPictures productPictures)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productPictures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productPictures.ProductId);
            return View(productPictures);
        }

        // GET: ProductPictures1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPictures = await _context.ProductPictures.FindAsync(id);
            if (productPictures == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productPictures.ProductId);
            return View(productPictures);
        }

        // POST: ProductPictures1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductImagePath")] ProductPictures productPictures)
        {
            if (id != productPictures.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productPictures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductPicturesExists(productPictures.ProductId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productPictures.ProductId);
            return View(productPictures);
        }

        // GET: ProductPictures1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPictures = await _context.ProductPictures
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productPictures == null)
            {
                return NotFound();
            }

            return View(productPictures);
        }

        // POST: ProductPictures1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productPictures = await _context.ProductPictures.FindAsync(id);
            _context.ProductPictures.Remove(productPictures);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPicturesExists(int id)
        {
            return _context.ProductPictures.Any(e => e.ProductId == id);
        }
    }
}
