using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
