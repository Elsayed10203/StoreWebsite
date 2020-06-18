using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class Product
    {
        public int ProdId { get; set; }
        public int? CatId { get; set; }
        public int? BrandId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescrp { get; set; }
        public int? ProdQuantity { get; set; }
        public decimal? Prodprice { get; set; }
        public int? Discound { get; set; }
        public string VendorName { get; set; }
        public string ProductAvailableLocation { get; set; }
        public string ProdColor { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Cat { get; set; }
    }
}
