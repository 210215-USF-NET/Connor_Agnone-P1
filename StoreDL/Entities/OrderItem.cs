using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderQuantity { get; set; }
        public int? OrdersId { get; set; }
        public int? OrderProduct { get; set; }

        public virtual Product OrderProductNavigation { get; set; }
        public virtual Order Orders { get; set; }
    }
}
