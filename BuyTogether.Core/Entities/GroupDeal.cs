namespace BuyTogether.Core.Entities
{
    public class GroupDeal
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal GroupPrice { get; set; }
        public int MinPeople { get; set; }
        public int MaxPeople { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Status { get; set; } = "Active"; // Active/ Filled / Expired

        public ICollection<GroupMember>? Members { get; set; }
    }
}
