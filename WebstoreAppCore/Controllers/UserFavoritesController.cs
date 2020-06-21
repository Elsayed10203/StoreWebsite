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
    public class UserFavoritesController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public UserFavoritesController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: UserFavorites
        public async Task<IActionResult> Index()
        {
            var storeWebsiteContext = _context.UserFavorites.Include(u => u.Product).Include(u => u.User);
            return View(await storeWebsiteContext.ToListAsync());
        }

        // GET: UserFavorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFavorites = await _context.UserFavorites
                .Include(u => u.Product)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userFavorites == null)
            {
                return NotFound();
            }

            return View(userFavorites);
        }

        // GET: UserFavorites/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address");
            return View();
        }

        // POST: UserFavorites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ProductId")] UserFavorites userFavorites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFavorites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", userFavorites.ProductId);
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userFavorites.UserId);
            return View(userFavorites);
        }

        // GET: UserFavorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFavorites = await _context.UserFavorites.FindAsync(id);
            if (userFavorites == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", userFavorites.ProductId);
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userFavorites.UserId);
            return View(userFavorites);
        }

        // POST: UserFavorites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ProductId")] UserFavorites userFavorites)
        {
            if (id != userFavorites.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFavorites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFavoritesExists(userFavorites.UserId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", userFavorites.ProductId);
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userFavorites.UserId);
            return View(userFavorites);
        }

        // GET: UserFavorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFavorites = await _context.UserFavorites
                .Include(u => u.Product)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userFavorites == null)
            {
                return NotFound();
            }

            return View(userFavorites);
        }

        // POST: UserFavorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userFavorites = await _context.UserFavorites.FindAsync(id);
            _context.UserFavorites.Remove(userFavorites);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFavoritesExists(int id)
        {
            return _context.UserFavorites.Any(e => e.UserId == id);
        }
    }
}
