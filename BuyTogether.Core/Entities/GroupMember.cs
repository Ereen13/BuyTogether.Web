namespace BuyTogether.Core.Entities
{
    public class GroupMember
    {
        public int Id { get; set; }
        public int GroupDealId { get; set; }
        public GroupDeal? GroupDeal { get; set; }
        public string UserId { get; set; } = string.Empty; // Identity user id
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
