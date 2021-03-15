using System.ComponentModel;
using StoreModels;
namespace MvcStore.Models
{
    public class LocationIVM
    {
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Price")]
        public decimal ProductPrice { get; set; }
        [DisplayName("Quantity")]
        public int InventroyQuantity { get; set; }

        public int LocationId { get; set; }

    }
}