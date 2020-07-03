using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebstoreAppCore.MobileRepository;
using WebStoreAppCore.Models;
using WebStoreAppCore.Repository;

namespace WebStoreAppCore.Controllers
{
    public class WebUsersController : Controller
    {
        private readonly StoreWebsiteContext _context;
        private readonly IProductRepository _products;
        private readonly IWebUserRepository _users;



        //test
        List<WebUsers> webUsers = new List<WebUsers>()
        {
            new WebUsers(){ UserId=1, UserName="ahmed", UserPassword="123", UserImagePath="nasr.jpg", Phone=01234567890, UserEmails={ new UserEmails() { UserId=1,Email="ahmednasr@gmail.com" } }, UserFavorites={new UserFavorites() { UserId=1, ProductId=1},new UserFavorites() { UserId=1, ProductId=2} }, Address="Mansoura"}
        };

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

        //endtest

        public WebUsersController(StoreWebsiteContext context, IProductRepository products, IWebUserRepository users)
        {
            _context = context;
            _products = products;
            _users = users;
        }


        public IActionResult Profile()
        {


            //test
            WebUsers user = webUsers.Find(p => p.UserId == 1);

            List<UserFavorites> prods = (from favs in user.UserFavorites
                                         where favs.UserId == user.UserId
                                         select favs).ToList();

            List<Products> mylist = new List<Products>();

            foreach (var item in prods)
            {
                mylist.Add(xproducts.Find(p => p.ProductId == item.ProductId));
            }

            ViewBag.fav = mylist;

            //database
            //WebUsers user = _users.getWebUser(1);
            //List<UserFavorites> prods = (from favs in user.UserFavorites
            //                             where favs.UserId == user.UserId
            //                             select favs).ToList();

            //List<Products> mylist = new List<Products>();

            //foreach (var item in prods)
            //{
            //    mylist.Add(_products.getProductByID(item.ProductId));
            //}

            //ViewBag.fav = mylist;

            return View(user);
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
