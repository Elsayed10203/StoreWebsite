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
    public class WebUsersController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public WebUsersController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: WebUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.WebUsers.ToListAsync());
        }

        // GET: WebUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webUsers = await _context.WebUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (webUsers == null)
            {
                return NotFound();
            }

            return View(webUsers);
        }

        // GET: WebUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,UserPassword,UserImagePath,Address,PostCode,Phone,BirthDate,IsOnline,NoOfAccess,CreationDate,NoOfBlock")] WebUsers webUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webUsers);
        }

        // GET: WebUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webUsers = await _context.WebUsers.FindAsync(id);
            if (webUsers == null)
            {
                return NotFound();
            }
            return View(webUsers);
        }

        // POST: WebUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,UserPassword,UserImagePath,Address,PostCode,Phone,BirthDate,IsOnline,NoOfAccess,CreationDate,NoOfBlock")] WebUsers webUsers)
        {
            if (id != webUsers.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebUsersExists(webUsers.UserId))
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
            return View(webUsers);
        }

        // GET: WebUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webUsers = await _context.WebUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (webUsers == null)
            {
                return NotFound();
            }

            return View(webUsers);
        }

        // POST: WebUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webUsers = await _context.WebUsers.FindAsync(id);
            _context.WebUsers.Remove(webUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebUsersExists(int id)
        {
            return _context.WebUsers.Any(e => e.UserId == id);
        }
    }
}
