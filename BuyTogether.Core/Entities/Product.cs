namespace BuyTogether.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal IndividualPrice { get; set; }
        public decimal? GroupPrice { get; set; }
        public bool IsActive { get; set; } = true;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<ProductImage>? Images { get; set; }
        public ICollection<GroupDeal>? GroupDeals { get; set; }
    }
}
