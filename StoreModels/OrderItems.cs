namespace StoreModels
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int OrderQuantity { get; set; }
        public Product OrderItemProduct { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}