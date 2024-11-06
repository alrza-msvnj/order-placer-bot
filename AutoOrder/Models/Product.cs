namespace AutoOrder.Models
{
    public record class Product
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}