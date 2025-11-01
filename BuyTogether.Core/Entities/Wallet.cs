namespace BuyTogether.Core.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public ICollection<WalletTransaction>? Transactions { get; set; }
    }
}
