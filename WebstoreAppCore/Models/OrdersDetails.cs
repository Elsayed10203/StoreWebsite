using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class OrdersDetails
    {
        public int? OrderId { get; set; }
        public int? ProdId { get; set; }
        public decimal? ProdPriceSale { get; set; }
        public int? ProdQuant { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Prod { get; set; }
    }
}
