using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class Adminshop
    {
        public int AddminId { get; set; }
        public string AdmUserName { get; set; }
        public string AdmPass { get; set; }
        public string ShopName { get; set; }
        public string ShopEmail { get; set; }
        public int? PhoneNo { get; set; }
        public string ShopAddrase { get; set; }
    }
}
