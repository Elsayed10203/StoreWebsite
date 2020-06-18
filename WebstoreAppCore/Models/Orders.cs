using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderPrice { get; set; }
        public int? DriverNo { get; set; }
        public DateTime? DriverDate { get; set; }
        public string Paid { get; set; }
        public string EmptyProductBin { get; set; }
        public int? UserId { get; set; }
        public int? PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual WebUser User { get; set; }
    }
}
