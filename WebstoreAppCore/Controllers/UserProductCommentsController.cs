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
    public class UserProductCommentsController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public UserProductCommentsController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: UserProductComments
        public async Task<IActionResult> Index()
        {
            var storeWebsiteContext = _context.UserProductComments.Include(u => u.Product).Include(u => u.User);
            return View(await storeWebsiteContext.ToListAsync());
        }

        // GET: UserProductComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProductComments = await _context.UserProductComments
                .Include(u => u.Product)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userProductComments == null)
            {
                return NotFound();
            }

            return View(userProductComments);
        }

        // GET: UserProductComments/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address");
            return View();
        }

        // POST: UserProductComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,MessageBody,MessageDate,ProductId")] UserProductComments userProductComments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProductComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", userProductComments.ProductId);
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userProductComments.UserId);
            return View(userProductComments);
        }

        // GET: UserProductComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProductComments = await _context.UserProductComments.FindAsync(id);
            if (userProductComments == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", userProductComments.ProductId);
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userProductComments.UserId);
            return View(userProductComments);
        }

        // POST: UserProductComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,MessageBody,MessageDate,ProductId")] UserProductComments userProductComments)
        {
            if (id != userProductComments.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProductComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProductCommentsExists(userProductComments.UserId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", userProductComments.ProductId);
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userProductComments.UserId);
            return View(userProductComments);
        }

        // GET: UserProductComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProductComments = await _context.UserProductComments
                .Include(u => u.Product)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userProductComments == null)
            {
                return NotFound();
            }

            return View(userProductComments);
        }

        // POST: UserProductComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProductComments = await _context.UserProductComments.FindAsync(id);
            _context.UserProductComments.Remove(userProductComments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProductCommentsExists(int id)
        {
            return _context.UserProductComments.Any(e => e.UserId == id);
        }
    }
}
