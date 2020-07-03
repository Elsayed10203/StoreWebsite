using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebstoreAppCore.MobileRepository;
using WebStoreAppCore.Models;
using X.PagedList;

namespace WebStoreAppCore.Controllers
{
    public class MobilePropertiesController : Controller
    {
        private readonly StoreWebsiteContext _context;
        private readonly IProductRepository _products;

        //test
        List<Products> xproducts = new List<Products>
        { new Products { ProductId=1,ProductName="Iphone11 pro Max",ProductPrice=230,IsOffer=true, ProductPictures={new ProductPictures(){ ProductId = 1, ProductImagePath = "iphone11max.jpg" } }, Brand= new Brands(){ BrandId=1,BrandName="Apple" },MobileProperties= new MobileProperties(){ ProductId=1, Battery="22", CameraPropertry="2mpx", OperatingSystem="OS", ScreenSize="333", Storage="203", WaterResist="checked", Ram="8" } },
          new Products { ProductId=2,ProductName="Galaxy Note10",ProductPrice=230,IsOffer=true, Brand= new Brands(){ BrandId=1,BrandName="Apple" },MobileProperties=new MobileProperties(){ ProductId=2, Battery="22", CameraPropertry="2mpx", OperatingSystem="OS", ScreenSize="333", Storage="203", WaterResist="checked", Ram="8" } },
          new Products { ProductId=3,ProductName="Iphone11 pro Max",ProductPrice=230,IsOffer=true, Brand= new Brands(){ BrandId=1,BrandName="Apple" },MobileProperties=new MobileProperties(){ ProductId=3, Battery="22", CameraPropertry="2mpx", OperatingSystem="OS", ScreenSize="333", Storage="203", WaterResist="checked", Ram="8" } },
          new Products { ProductId=4,ProductName="Galaxy Note10",ProductPrice=230,IsOffer=true, Brand=new Brands(){ BrandId=1,BrandName="Apple" },MobileProperties=new MobileProperties(){ ProductId=4, Battery="22", CameraPropertry="2mpx", OperatingSystem="OS", ScreenSize="333", Storage="203", WaterResist="checked", Ram="8" } },
          new Products { ProductId=5,ProductName="Oppo 20",ProductPrice=230,IsOffer=false, Brand=new Brands(){ BrandId=1,BrandName="Apple" },MobileProperties=new MobileProperties(){ ProductId=5, Battery="22", CameraPropertry="2mpx", OperatingSystem="OS", ScreenSize="333", Storage="203", WaterResist="checked", Ram="8" } },
          new Products { ProductId=6,ProductName="Galaxy Note10",ProductPrice=230,IsOffer=true, Brand=new Brands(){ BrandId=1,BrandName="Apple" },MobileProperties=new MobileProperties(){ ProductId=6, Battery="22", CameraPropertry="2mpx", OperatingSystem="OS", ScreenSize="333", Storage="203", WaterResist="checked", Ram="8" } },
          new Products { ProductId=7,ProductName="Iphone11 pro Max",ProductPrice=230,IsOffer=true, Brand=new Brands(){ BrandId=1,BrandName="Apple" },MobileProperties=new MobileProperties(){ ProductId=7, Battery="22", CameraPropertry="2mpx", OperatingSystem="OS", ScreenSize="333", Storage="203", WaterResist="checked", Ram="8" } },
          new Products { ProductId=8,ProductName="Oppo 20",ProductPrice=230,IsOffer=false, Brand=new Brands(){ BrandId=1,BrandName="Apple" },MobileProperties=new MobileProperties(){ ProductId=8, Battery="22", CameraPropertry="2mpx", OperatingSystem="OS", ScreenSize="333", Storage="203", WaterResist="checked", Ram="8" } }

        };

        public MobilePropertiesController(StoreWebsiteContext context, IProductRepository products)
        {
            _context = context;
            _products = products;
        }

        // GET: MobileProperties
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1; // if no page is specified, default to the first page (1)
            int pageSize = 4;          // Get 15 Mobiles for each requested page.
            var storeWebsiteContext = xproducts.ToPagedList(pageNumber, pageSize);
            return View(storeWebsiteContext);
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
