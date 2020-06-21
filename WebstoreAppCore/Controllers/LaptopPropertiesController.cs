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
    public class LaptopPropertiesController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public LaptopPropertiesController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: LaptopProperties
        public async Task<IActionResult> Index()
        {
            var storeWebsiteContext = _context.LaptopProperties.Include(l => l.Product);
            return View(await storeWebsiteContext.ToListAsync());
        }

        // GET: LaptopProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopProperties = await _context.LaptopProperties
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (laptopProperties == null)
            {
                return NotFound();
            }

            return View(laptopProperties);
        }

        // GET: LaptopProperties/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: LaptopProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ScreenSize,ScreenType,Ram,CameraPropertry,Battery,ModeNo,FingerPrint,WaterResist,Processor,HardType,HardStorage,Genaration,ExtraProperty")] LaptopProperties laptopProperties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptopProperties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", laptopProperties.ProductId);
            return View(laptopProperties);
        }

        // GET: LaptopProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopProperties = await _context.LaptopProperties.FindAsync(id);
            if (laptopProperties == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", laptopProperties.ProductId);
            return View(laptopProperties);
        }

        // POST: LaptopProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ScreenSize,ScreenType,Ram,CameraPropertry,Battery,ModeNo,FingerPrint,WaterResist,Processor,HardType,HardStorage,Genaration,ExtraProperty")] LaptopProperties laptopProperties)
        {
            if (id != laptopProperties.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptopProperties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopPropertiesExists(laptopProperties.ProductId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", laptopProperties.ProductId);
            return View(laptopProperties);
        }

        // GET: LaptopProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopProperties = await _context.LaptopProperties
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (laptopProperties == null)
            {
                return NotFound();
            }

            return View(laptopProperties);
        }

        // POST: LaptopProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptopProperties = await _context.LaptopProperties.FindAsync(id);
            _context.LaptopProperties.Remove(laptopProperties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopPropertiesExists(int id)
        {
            return _context.LaptopProperties.Any(e => e.ProductId == id);
        }
    }
}
