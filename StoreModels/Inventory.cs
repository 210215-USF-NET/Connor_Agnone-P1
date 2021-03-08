namespace StoreModels
{
    public class Inventory
    {
        public Product InventoryProduct { get; set ;}
        public int InventoryQuantity { get; set; }
        public int? InventoryID { get; set; }
        public int? ProductID { get; set; } 
        public int? LocationID { get; set; } 
        public override string ToString() => (this.ProductID + "| ");
    }
}