namespace StoreModels
{
    public class OrderItems
    {
        public int? OrderItemID { get; set; }
        public int OrderQuantity { get; set; }
        public Product OrderItemProduct { get; set; }
        public int? OrderID { get; set; }
    }
}