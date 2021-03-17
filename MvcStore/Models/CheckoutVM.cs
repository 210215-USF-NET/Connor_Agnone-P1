using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using StoreModels;
namespace MvcStore.Models
{
    public class CheckoutVM
    {
        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }
        [DisplayName("Price")]
        [Required]
        public decimal ProductPrice { get; set; }
        [DisplayName("Quantity")]
        [Required]
        public int Quantity { get; set; }
        public int ProductID { get; set; }
    }
}