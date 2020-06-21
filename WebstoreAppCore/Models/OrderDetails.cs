using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
