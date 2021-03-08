using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderCustomer { get; set; }
        public int? OrderLocation { get; set; }

        public virtual Customer OrderCustomerNavigation { get; set; }
        public virtual Location OrderLocationNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
