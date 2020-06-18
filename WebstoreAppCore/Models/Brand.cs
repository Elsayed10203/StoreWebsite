using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Product = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescrp { get; set; }
        public string BrandLogoPicturePath { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
