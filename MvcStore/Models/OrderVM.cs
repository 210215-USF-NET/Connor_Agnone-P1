using System.ComponentModel;
using StoreModels;
using System;
namespace MvcStore.Models
{
    public class OrderVM
    {
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        public int CustomerID { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
    }
}