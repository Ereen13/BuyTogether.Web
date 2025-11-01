namespace BuyTogether.Core.Entities
{
    public class ShippingTracking
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public string Carrier { get; set; } = string.Empty;
        public string TrackingNumber { get; set; } = string.Empty;
        public string Status { get; set; } = "Created";
        public DateTime? LastUpdated { get; set; }
    }
}
