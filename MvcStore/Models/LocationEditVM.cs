using System.ComponentModel;
using StoreModels;
using System.ComponentModel.DataAnnotations;
namespace MvcStore.Models
{
    public class LocationEditVM
    {
        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }
        [DisplayName("Price")]
        [Required]
        public decimal ProductPrice { get; set; }
        [DisplayName("Quantity")]
        [Required]
        public int InventoryQuantity { get; set; }

        public int LocationId { get; set; }
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
    }
}