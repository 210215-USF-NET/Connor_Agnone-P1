namespace StoreModels
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int? CustomerID { get; set; }
        public Order CustomerOrder { get; set; }
        public override string ToString() => $"Customer Details:\n\tName: {this.CustomerName}\n\tEmail: {this.CustomerEmail}";
    }
}