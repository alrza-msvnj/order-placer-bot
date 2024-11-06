namespace AutoOrder.Models
{
    public record class Order
    {
        public Customer Customer { get; set; } = new Customer();
        public List<Product> Products { get; set; } = new List<Product>();
        public Address Address { get; set; } = new Address();
        public string CustomerDescription { get; set; }
        public string Gateway { get; set; }
        public string SMSMobile { get; set; }
        public int OrderCount { get; set; }
        public OrderDelayToSeconds OrderDelayToSeconds { get; set; } = new OrderDelayToSeconds();
    }
}
