namespace BuyTogether.Core.Entities
{
    public class WalletTransaction
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public Wallet? Wallet { get; set; }
        public decimal Amount { get; set; } // positive = credit, negative = debit
        public string Type { get; set; } = "Refund"; // Refund, Purchase, TopUp
        public string? Reference { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
