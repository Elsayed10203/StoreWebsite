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
    public class MobilePropertiesController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public MobilePropertiesController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: MobileProperties
        public async Task<IActionResult> Index()
        {
            var storeWebsiteContext = _context.MobileProperties.Include(m => m.Product);
            return View(await storeWebsiteContext.ToListAsync());
        }

        // GET: MobileProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileProperties = await _context.MobileProperties
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (mobileProperties == null)
            {
                return NotFound();
            }

            return View(mobileProperties);
        }

        // GET: MobileProperties/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: MobileProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ScreenSize,ScreenType,Ram,CameraPropertry,Battery,ModeNo,FingerPrint,WaterResist,Sim,OperatingSystem,Storage,ExtraProperty")] MobileProperties mobileProperties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobileProperties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", mobileProperties.ProductId);
            return View(mobileProperties);
        }

        // GET: MobileProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileProperties = await _context.MobileProperties.FindAsync(id);
            if (mobileProperties == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", mobileProperties.ProductId);
            return View(mobileProperties);
        }

        // POST: MobileProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ScreenSize,ScreenType,Ram,CameraPropertry,Battery,ModeNo,FingerPrint,WaterResist,Sim,OperatingSystem,Storage,ExtraProperty")] MobileProperties mobileProperties)
        {
            if (id != mobileProperties.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobileProperties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobilePropertiesExists(mobileProperties.ProductId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", mobileProperties.ProductId);
            return View(mobileProperties);
        }

        // GET: MobileProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileProperties = await _context.MobileProperties
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (mobileProperties == null)
            {
                return NotFound();
            }

            return View(mobileProperties);
        }

        // POST: MobileProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobileProperties = await _context.MobileProperties.FindAsync(id);
            _context.MobileProperties.Remove(mobileProperties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobilePropertiesExists(int id)
        {
            return _context.MobileProperties.Any(e => e.ProductId == id);
        }
    }
}
