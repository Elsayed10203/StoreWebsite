using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class ProductPictures
    {
        public int? ProdId { get; set; }
        public string ProdImagePath { get; set; }

        public virtual Product Prod { get; set; }
    }
}
