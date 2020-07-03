using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebstoreAppCore.MobileRepository;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Controllers
{
    public class ProductsController : Controller
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


        //List<Products> xproducts = new List<Products>
        //{ new Products { ProductId=1,ProductName="Iphone11 pro Max",ProductPrice=230,IsOffer=true},
        //  new Products { ProductId=2,ProductName="Galaxy Note10",ProductPrice=230,IsOffer=true},
        //  new Products { ProductId=3,ProductName="Iphone11 pro Max",ProductPrice=230,IsOffer=true },
        //  new Products { ProductId=4,ProductName="Galaxy Note10",ProductPrice=230,IsOffer=true},
        //  new Products { ProductId=5,ProductName="Oppo 20",ProductPrice=230,IsOffer=false },
        //  new Products { ProductId=6,ProductName="Galaxy Note10",ProductPrice=230,IsOffer=true},
        //  new Products { ProductId=7,ProductName="Iphone11 pro Max",ProductPrice=230,IsOffer=true },
        //  new Products { ProductId=8,ProductName="Oppo 20",ProductPrice=230,IsOffer=false}

        //};

        List<WebUsers> webUsers = new List<WebUsers>()
        {
            new WebUsers(){ UserId=1, UserName="ahmed", UserPassword="123", UserFavorites={new UserFavorites() { UserId=1, ProductId=1} }, Address="Mansoura"}
        };


        //end test

        public ProductsController(IProductRepository products, StoreWebsiteContext context)
        {
            _context = context;
            _products = products;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var storeWebsiteContext = _context.Products.Include(p => p.Brand).Include(p => p.Category);
            return View(await storeWebsiteContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CategoryId,BrandId,ProductName,ProductDescription,ProductQuantity,ProductPrice,Discount,VendorName,ProductColor,ProductRate,IsOffer")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", products.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", products.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CategoryId,BrandId,ProductName,ProductDescription,ProductQuantity,ProductPrice,Discount,VendorName,ProductColor,ProductRate,IsOffer")] Products products)
        {
            if (id != products.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductId))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", products.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public IActionResult Offers()
        {
            //test
            return View(xproducts.Where(p => p.IsOffer == true).ToList());

            //database
            //return View(_products.getDiscountedProducts().ToList());
        }

        public IActionResult ProductDetails(int id)
        {
            //test
            Products product = xproducts.Find(p => p.ProductId == id);
            ViewBag.ProductPics = product.ProductPictures;



            //database
            //Products product = _products.getProductByID(id);
            //ViewBag.ProductPics = _products.getProductPictures(id);

            return View(product);
        }

        public IActionResult addToFavorites(int productid,int userid=1)
        {
            //test
            WebUsers xuser= webUsers.Find(p => p.UserId == userid);
            xuser.UserFavorites.Add(new UserFavorites() { UserId = xuser.UserId, ProductId = productid });


            //database
            //_products.addToFavorites(productid,1);

            return View(nameof(Offers));
        }
    }
}
