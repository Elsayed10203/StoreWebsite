using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebstoreAppCore.Models;

namespace WebstoreAppCore.Controllers
{
    public class MobileController : Controller
    {
        private readonly StoreWebsiteContext _context;

        public MobileController(StoreWebsiteContext context)
        {
            _context = context;
        }
       
    }
}