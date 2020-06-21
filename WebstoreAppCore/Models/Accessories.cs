using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class Accessories
    {
        public int ProductId { get; set; }
        public int AccessoryTypeId { get; set; }

        public virtual AccessoryTypes AccessoryType { get; set; }
        public virtual Products Product { get; set; }
    }
}
