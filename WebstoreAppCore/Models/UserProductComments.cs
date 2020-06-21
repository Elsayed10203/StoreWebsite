using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class UserProductComments
    {
        public int UserId { get; set; }
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
        public virtual WebUsers User { get; set; }
    }
}
