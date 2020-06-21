using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class AccessoryTypes
    {
        public AccessoryTypes()
        {
            Accessories = new HashSet<Accessories>();
        }

        public int AccessoryTypeId { get; set; }
        public string AccessoryType { get; set; }

        public virtual ICollection<Accessories> Accessories { get; set; }
    }
}
