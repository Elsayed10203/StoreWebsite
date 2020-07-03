using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebstoreAppCore.MobileRepository;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Controllers
{
    public class WelcomeController : Controller
    {

        private readonly StoreWebsiteContext _context;
        private readonly IProductRepository _products;


        //test
        List<Ads> ads = new List<Ads> { new Ads { AdId=1,AdPictuer="1.png",IsDisplay=true},
            new Ads { AdId=2,AdPictuer="1.png",IsDisplay=true},
            new Ads { AdId=3,AdPictuer="1.png",IsDisplay=true}
        };

        List<Products> products = new List<Products>
        { new Products { ProductId=1,ProductName="Iphone11 pro Max",ProductPrice=230,MobileProperties=new MobileProperties(){ ProductId=1, Battery="200"} },
          new Products { ProductId=2,ProductName="Galaxy Note10",ProductPrice=230 },
          new Products { ProductId=3,ProductName="Iphone11 pro Max",ProductPrice=230 },
          new Products { ProductId=4,ProductName="Galaxy Note10",ProductPrice=230 },
          new Products { ProductId=5,ProductName="Oppo 20",ProductPrice=230 },
          new Products { ProductId=6,ProductName="Galaxy Note10",ProductPrice=230 },
          new Products { ProductId=7,ProductName="Iphone11 pro Max",ProductPrice=230 },
          new Products { ProductId=8,ProductName="Oppo 20",ProductPrice=230 }

        };

        List<Products> Accproducts = new List<Products>
        { new Products { ProductId=1,ProductName="Battery",ProductPrice=230 },
          new Products { ProductId=2,ProductName="PowerBank",ProductPrice=230 },
          new Products { ProductId=3,ProductName="Headphone",ProductPrice=230 },
          new Products { ProductId=4,ProductName="Airpods",ProductPrice=230 },
          new Products { ProductId=5,ProductName="Charger",ProductPrice=230 },
          new Products { ProductId=6,ProductName="USB",ProductPrice=230 },
          new Products { ProductId=7,ProductName="Apple Charger",ProductPrice=230 },
          new Products { ProductId=8,ProductName="IPcover",ProductPrice=230 }

        };

        //endtest

        public WelcomeController(IProductRepository products, StoreWebsiteContext context)
        {
            _products = products;
            _context = context;


        }

        public async Task<IActionResult> Index()
        {
            /* ViewBag.Mobiles = products;*/
            ViewBag.Mobiles = _context.Products.ToList();
            ViewBag.Accessories = Accproducts;
            return View(await _context.Ads.ToListAsync());
        }
        public IActionResult MobileSlide()
        {
            ViewBag.Mobiles = _context.Products.ToList();
            return View();
        }
        public IActionResult AccessoriesSlide()
        {
            ViewBag.Accessories = Accproducts;
            return View();
        }

    }
}
