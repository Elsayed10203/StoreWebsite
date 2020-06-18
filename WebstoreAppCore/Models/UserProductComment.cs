using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class UserProductComment
    {
        public int? UserId { get; set; }
        public string MessgeBody { get; set; }
        public DateTime? MessageDate { get; set; }
        public int? ProdId { get; set; }

        public virtual Product Prod { get; set; }
        public virtual WebUser User { get; set; }
    }
}
