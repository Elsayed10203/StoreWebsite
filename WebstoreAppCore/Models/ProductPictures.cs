using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class ProductPictures
    {
        public int ProductId { get; set; }
        public string ProductImagePath { get; set; }

        public virtual Products Product { get; set; }
    }
}
