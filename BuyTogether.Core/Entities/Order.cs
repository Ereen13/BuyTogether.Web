namespace BuyTogether.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty; // Identity user id
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Shipped, Delivered, Refunded

        public ICollection<OrderItem>? Items { get; set; }
        public ShippingTracking? ShippingTracking { get; set; }
    }
}
