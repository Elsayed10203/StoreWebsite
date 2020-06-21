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
    public class AccessoryTypesController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public AccessoryTypesController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: AccessoryTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccessoryTypes.ToListAsync());
        }

        // GET: AccessoryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessoryTypes = await _context.AccessoryTypes
                .FirstOrDefaultAsync(m => m.AccessoryTypeId == id);
            if (accessoryTypes == null)
            {
                return NotFound();
            }

            return View(accessoryTypes);
        }

        // GET: AccessoryTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccessoryTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccessoryTypeId,AccessoryType")] AccessoryTypes accessoryTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessoryTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accessoryTypes);
        }

        // GET: AccessoryTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessoryTypes = await _context.AccessoryTypes.FindAsync(id);
            if (accessoryTypes == null)
            {
                return NotFound();
            }
            return View(accessoryTypes);
        }

        // POST: AccessoryTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccessoryTypeId,AccessoryType")] AccessoryTypes accessoryTypes)
        {
            if (id != accessoryTypes.AccessoryTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessoryTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessoryTypesExists(accessoryTypes.AccessoryTypeId))
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
            return View(accessoryTypes);
        }

        // GET: AccessoryTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessoryTypes = await _context.AccessoryTypes
                .FirstOrDefaultAsync(m => m.AccessoryTypeId == id);
            if (accessoryTypes == null)
            {
                return NotFound();
            }

            return View(accessoryTypes);
        }

        // POST: AccessoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessoryTypes = await _context.AccessoryTypes.FindAsync(id);
            _context.AccessoryTypes.Remove(accessoryTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessoryTypesExists(int id)
        {
            return _context.AccessoryTypes.Any(e => e.AccessoryTypeId == id);
        }
    }
}
