using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class Payments
    {
        public Payments()
        {
            Orders = new HashSet<Orders>();
        }

        public int PaymentId { get; set; }
        public string PaymentType { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
