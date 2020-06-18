using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Orders>();
        }

        public int PaymentId { get; set; }
        public string PaymentType { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
