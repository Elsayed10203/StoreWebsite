using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStoreAppCore.Models;
using WebStoreAppCore.Repository;

namespace WebStoreAppCore.Controllers
{
    public class AdminshopsController : Controller
    {
        private readonly StoreWebsiteContext _context;
        IShopRepository _shop;
        public AdminshopsController(StoreWebsiteContext context, IShopRepository shop)
        {
            _context = context;
            _shop = shop;

        }

        // GET: Adminshops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adminshop.ToListAsync());
        }

        // GET: Adminshops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminshop = await _context.Adminshop
                .FirstOrDefaultAsync(m => m.AdminShopId == id);
            if (adminshop == null)
            {
                return NotFound();
            }

            return View(adminshop);
        }

        // GET: Adminshops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adminshops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminShopId,UserName,UserPassword,ShopName,ShopEmail,PhoneNo,ShopAddress")] Adminshop adminshop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminshop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminshop);
        }

        // GET: Adminshops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminshop = await _context.Adminshop.FindAsync(id);
            if (adminshop == null)
            {
                return NotFound();
            }
            return View(adminshop);
        }

        // POST: Adminshops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminShopId,UserName,UserPassword,ShopName,ShopEmail,PhoneNo,ShopAddress")] Adminshop adminshop)
        {
            if (id != adminshop.AdminShopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminshop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminshopExists(adminshop.AdminShopId))
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
            return View(adminshop);
        }

        // GET: Adminshops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminshop = await _context.Adminshop
                .FirstOrDefaultAsync(m => m.AdminShopId == id);
            if (adminshop == null)
            {
                return NotFound();
            }

            return View(adminshop);
        }

        // POST: Adminshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminshop = await _context.Adminshop.FindAsync(id);
            _context.Adminshop.Remove(adminshop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminshopExists(int id)
        {
            return _context.Adminshop.Any(e => e.AdminShopId == id);
        }

        public IActionResult ContactUs()
        {
            return View(_shop.getShopData());
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
