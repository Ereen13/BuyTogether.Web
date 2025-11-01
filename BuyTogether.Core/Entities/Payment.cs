namespace BuyTogether.Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } = string.Empty; // VodafoneCash, Meeza, Card
        public string Status { get; set; } = "Success"; // Success, Failed, Pending
        public string? ProviderReference { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
