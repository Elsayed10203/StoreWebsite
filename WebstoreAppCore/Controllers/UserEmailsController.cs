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
    public class UserEmailsController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public UserEmailsController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: UserEmails
        public async Task<IActionResult> Index()
        {
            var storeWebsiteContext = _context.UserEmails.Include(u => u.User);
            return View(await storeWebsiteContext.ToListAsync());
        }

        // GET: UserEmails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEmails = await _context.UserEmails
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userEmails == null)
            {
                return NotFound();
            }

            return View(userEmails);
        }

        // GET: UserEmails/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address");
            return View();
        }

        // POST: UserEmails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Email")] UserEmails userEmails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userEmails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userEmails.UserId);
            return View(userEmails);
        }

        // GET: UserEmails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEmails = await _context.UserEmails.FindAsync(id);
            if (userEmails == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userEmails.UserId);
            return View(userEmails);
        }

        // POST: UserEmails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Email")] UserEmails userEmails)
        {
            if (id != userEmails.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEmails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEmailsExists(userEmails.UserId))
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
            ViewData["UserId"] = new SelectList(_context.WebUsers, "UserId", "Address", userEmails.UserId);
            return View(userEmails);
        }

        // GET: UserEmails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEmails = await _context.UserEmails
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userEmails == null)
            {
                return NotFound();
            }

            return View(userEmails);
        }

        // POST: UserEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userEmails = await _context.UserEmails.FindAsync(id);
            _context.UserEmails.Remove(userEmails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEmailsExists(int id)
        {
            return _context.UserEmails.Any(e => e.UserId == id);
        }
    }
}
