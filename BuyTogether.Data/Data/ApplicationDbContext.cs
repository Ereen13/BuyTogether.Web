using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BuyTogether.Core.Entities;

namespace BuyTogether.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<ProductImage> ProductImages { get; set; } = default!;
        public DbSet<GroupDeal> GroupDeals { get; set; } = default!;
        public DbSet<GroupMember> GroupMembers { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
        public DbSet<Wallet> Wallets { get; set; } = default!;
        public DbSet<WalletTransaction> WalletTransactions { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<ShippingTracking> ShippingTrackings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // decimals
            builder.Entity<Product>().Property(p => p.IndividualPrice).HasColumnType("decimal(18,2)");
            builder.Entity<Product>().Property(p => p.GroupPrice).HasColumnType("decimal(18,2)");
            builder.Entity<OrderItem>().Property(i => i.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Entity<Wallet>().Property(w => w.Balance).HasColumnType("decimal(18,2)");
            builder.Entity<WalletTransaction>().Property(t => t.Amount).HasColumnType("decimal(18,2)");
            builder.Entity<Payment>().Property(p => p.Amount).HasColumnType("decimal(18,2)");

            // indexes
            builder.Entity<Product>().HasIndex(p => p.Slug).IsUnique();
            builder.Entity<GroupDeal>().HasIndex(g => g.EndAt);
            builder.Entity<Order>().HasIndex(o => o.UserId);
            builder.Entity<Wallet>().HasIndex(w => w.UserId);

            // relationships
            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasMany(p => p.GroupDeals)
                .WithOne(g => g.Product)
                .HasForeignKey(g => g.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // concurrency token (optional)
            builder.Entity<Product>().Property<byte[]>("RowVersion").IsRowVersion();
        }
    }
}
