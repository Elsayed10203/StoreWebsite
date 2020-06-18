using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatDescrp { get; set; }
        public string CatPicturePath { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
