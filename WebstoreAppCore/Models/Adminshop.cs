using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class Adminshop
    {
        public int AdminShopId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string ShopName { get; set; }
        public string ShopEmail { get; set; }
        public int PhoneNo { get; set; }
        public string ShopAddress { get; set; }
    }
}
