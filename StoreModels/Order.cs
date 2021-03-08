using System;
using System.Collections.Generic;
namespace StoreModels
{
    public class Order
    {
        public decimal OrderTotal { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderID { get; set; }
        public int? LocationID { get; set; }
        public int? CustomerID { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
