using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using WebstoreAppCore;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public CategoriesController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Categories categories, IFormFile _Imag)
        {

            if (ModelState.IsValid)
            {
                categories.CategoryId = GetMaxGatagNo();
                _context.Add(categories);
                await _context.SaveChangesAsync();
                SaveCatg_Image(categories, _Imag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categories);
        }
        int  GetMaxGatagNo()
        {
            return ((_context.Categories.Select(x => x.CategoryId).Max()) + 1);
        }
        void SaveCatg_Image(Categories _Catg, IFormFile _Imag)
        {
            try
            {

                string ImagePath = string.Empty;
                string FileExtension = "";
                if (_Imag != null)
                {

                    if (_Imag.Length > 0)
                    {
                        FileExtension = Path.GetExtension(_Imag.FileName);
                        ImagePath = Directory.GetCurrentDirectory();
                        ImagePath = Path.Combine(ImagePath, "wwwroot", "Images", "CatagoriesPic", $"{_Catg.CategoryId}{FileExtension}");
                        FileStream fs = new FileStream(ImagePath, FileMode.Create);
                        _Imag.CopyTo(fs);
                        fs.Close();
                    }
                    _Catg.CategoryPicturePath = $"{_Catg.CategoryId}{FileExtension}";
                }
                else
                {
                    _Catg.CategoryPicturePath = "";

                }
            }
            catch(Exception ex)
            {
                int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                ErrorTb err = new ErrorTb()
                {
                    ErrDate = DateTime.Now,
                    ErrId = (_context.ErrorTb.Select(x => x.ErrId).Max()) + 1,
                    ErrMessage = ex.GetType().Name,
                    ErrLine = lineNumber,
                };
                _context.ErrorTb.Add(err);
                _context.SaveChanges();
            }
        }
  

    // GET: Categories/Edit/5
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CategoryDescription,CategoryPicturePath")] Categories categories, IFormFile _Image)
        {
            if (id != categories.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if(_Image != null)
                {
                    SaveCatg_Image(categories, _Image);
                    _context.SaveChanges();

                }
                try
                {
                    _context.Update(categories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.CategoryId))
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
            return View(categories);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            Delete_Resources(categories);
            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        void Delete_Resources(Categories _Catag)
        {
            if (_Catag.CategoryPicturePath != string.Empty || _Catag.CategoryPicturePath != null)
            {
                string Root_Path = Directory.GetCurrentDirectory();
                string FullPath = Path.Combine(Root_Path, "wwwroot", "Images", "CatagoriesPic", _Catag.CategoryPicturePath);
                System.IO.File.Delete(FullPath);

            }
        }
        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

    }
}
