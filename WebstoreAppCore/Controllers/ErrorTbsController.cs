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
    public class ErrorTbsController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public ErrorTbsController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: ErrorTbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ErrorTb.ToListAsync());
        }

        // GET: ErrorTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var errorTb = await _context.ErrorTb
                .FirstOrDefaultAsync(m => m.ErrId == id);
            if (errorTb == null)
            {
                return NotFound();
            }

            return View(errorTb);
        }

        // GET: ErrorTbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ErrorTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ErrId,ErrMessage,ErrDate,ErrPageName,ErrLine,ErrDetails")] ErrorTb errorTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(errorTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(errorTb);
        }

        // GET: ErrorTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var errorTb = await _context.ErrorTb.FindAsync(id);
            if (errorTb == null)
            {
                return NotFound();
            }
            return View(errorTb);
        }

        // POST: ErrorTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ErrId,ErrMessage,ErrDate,ErrPageName,ErrLine,ErrDetails")] ErrorTb errorTb)
        {
            if (id != errorTb.ErrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(errorTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErrorTbExists(errorTb.ErrId))
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
            return View(errorTb);
        }

        // GET: ErrorTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var errorTb = await _context.ErrorTb
                .FirstOrDefaultAsync(m => m.ErrId == id);
            if (errorTb == null)
            {
                return NotFound();
            }

            return View(errorTb);
        }

        // POST: ErrorTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var errorTb = await _context.ErrorTb.FindAsync(id);
            _context.ErrorTb.Remove(errorTb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErrorTbExists(int id)
        {
            return _context.ErrorTb.Any(e => e.ErrId == id);
        }
    }
}
