using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Controllers
{
    public class BrandsController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public BrandsController(StoreWebsiteContext context)
        {
            _context = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brands == null)
            {
                return NotFound();
            }

            return View(brands);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,BrandName,BrandDescription,BrandLogoPicturePath")] Brands brands, IFormFile _Imag)
        {
            if (ModelState.IsValid)
            {
                brands.BrandId = GetMaxBrandNo();
                _context.Add(brands);
                await _context.SaveChangesAsync();
                SaveBrand_Image(brands, _Imag);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(brands);
        }

        void SaveBrand_Image(Brands _Brand, IFormFile _Imag)
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
                        ImagePath = Path.Combine(ImagePath, "wwwroot", "Images", "BrandsLogo", $"{_Brand.BrandId}{FileExtension}");
                        FileStream fs = new FileStream(ImagePath, FileMode.Create);
                       _Imag.CopyTo(fs);
                        fs.Close();
                    }
                    _Brand.BrandLogoPicturePath = $"{_Brand.BrandId}{FileExtension}";
                }
                else
                {
                    _Brand.BrandLogoPicturePath ="";
                }
            }
            catch (Exception ex)
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

        int GetMaxBrandNo()
        {
            return ((_context.Brands.Select(x => x.BrandId).Max()) + 1);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands.FindAsync(id);
            if (brands == null)
            {
                return NotFound();
            }
            return View(brands);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,BrandName,BrandDescription,BrandLogoPicturePath")] Brands brands,IFormFile _Imag)
        {

            if (id != brands.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if(_Imag!=null)
                {
                    SaveBrand_Image(brands, _Imag);
                    _context.SaveChanges();
                }
                try
                {
                    _context.Update(brands);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandsExists(brands.BrandId))
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
            return View(brands);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brands == null)
            {
                return NotFound();
            }

            return View(brands);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brands = await _context.Brands.FindAsync(id);
            _context.Brands.Remove(brands);
            Delete_Resources(brands);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        void Delete_Resources(Brands _brands)
        {
            try
            {
                if (_brands.BrandLogoPicturePath != string.Empty || _brands.BrandLogoPicturePath != null)
                {
                    string Root_Path = Directory.GetCurrentDirectory();
                    string FullPath = Path.Combine(Root_Path, "wwwroot", "Images", "BrandsLogo", _brands.BrandLogoPicturePath);
                    if (FullPath != null)
                    {
                        System.IO.File.Delete(FullPath);
                    }

                }
            }
            catch (Exception ex)
            {
                int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                ErrorTb tb = new ErrorTb()
                {
                    ErrId = (_context.ErrorTb.Select(x => x.ErrId).Max()) + 1,
                    ErrMessage = ex.GetType().Name,
                    ErrDate = DateTime.Now,
                    ErrLine = lineNumber
                };
                _context.Add(tb);
                _context.SaveChanges();
            }
        }
        private bool BrandsExists(int id)
        {
            return _context.Brands.Any(e => e.BrandId == id);
        }
    }
}
