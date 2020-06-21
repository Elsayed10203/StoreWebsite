using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class Brands
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public string BrandLogoPicturePath { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
