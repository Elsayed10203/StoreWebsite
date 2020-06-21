using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class Products
    {
        public Products()
        {
            Accessories = new HashSet<Accessories>();
            OrderDetails = new HashSet<OrderDetails>();
            ProductPictures = new HashSet<ProductPictures>();
            UserFavorites = new HashSet<UserFavorites>();
            UserProductComments = new HashSet<UserProductComments>();
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public int? Discount { get; set; }
        public string VendorName { get; set; }
        public string ProductColor { get; set; }
        public int? ProductRate { get; set; }
        public bool IsOffer { get; set; }

        public virtual Brands Brand { get; set; }
        public virtual Categories Category { get; set; }
        public virtual LaptopProperties LaptopProperties { get; set; }
        public virtual MobileProperties MobileProperties { get; set; }
        public virtual ICollection<Accessories> Accessories { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductPictures> ProductPictures { get; set; }
        public virtual ICollection<UserFavorites> UserFavorites { get; set; }
        public virtual ICollection<UserProductComments> UserProductComments { get; set; }
    }
}
