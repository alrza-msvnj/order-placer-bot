namespace AutoOrder.Models
{
    public record class OrderDelayToSeconds
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
