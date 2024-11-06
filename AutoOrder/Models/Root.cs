namespace AutoOrder.Models
{
    public record class Root
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}