using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreAppCore.payment;
using Stripe;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Controllers
{
    public class PaystripeController : Controller
    {

       [HttpPost]
        public IActionResult Index(string ProdPrice)
        {

             if(ProdPrice!=null)
              {
                decimal _ProdPrice = decimal.Parse(ProdPrice);
                ViewBag.ProdPrice = _ProdPrice;
                  return View();
              }
              else
              {
                  return Content("Select ACorrect Item");
              }

        }

        public IActionResult Privacy()
        {

            return View();
        }
        public IActionResult Error()
        {

            return View();
        }
        public IActionResult Charge(String stripeEmail, String stripeTooken)
        {
            var customers = new CustomerService();
            var Charges = new ChargeService();
            var customer = customers.Create(new CustomerCreateOptions { 
            Email=stripeEmail,
            
            });
            var Charge = Charges.Create(new ChargeCreateOptions
            {
                Amount = 5000,
                Description = "paymentname",
                Currency = "usd",
                ReceiptEmail = stripeEmail,
                Metadata = new Dictionary<string, string>()
                {
                    {"orderid" ,"111"  },
                    {"postcode","sayed" }
                }
            });
            if (Charge.Status=="succeeded")
            {
                String BalancyTransactionId = Charge.BalanceTransactionId;
                return View();
            }
            
            return View();
        }

       
    }
}