namespace StoreModels
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int Id { get; set; }
        public Order CustomerOrder { get; set; }
    }
}