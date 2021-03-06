namespace StoreModels
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Id { get; set; }
        public override string ToString() => $"Name: {this.ProductName} | Price: ${this.ProductPrice}";
    }
}