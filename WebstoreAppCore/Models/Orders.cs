using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }
        public int? DriverNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsProductBinEmpty { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }

        public virtual Payments Payment { get; set; }
        public virtual WebUsers User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
