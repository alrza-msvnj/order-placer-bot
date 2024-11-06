namespace AutoOrder.Models
{
    public record class Address
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
    }
}
