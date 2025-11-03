using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTogether.Core.Entities;
using BuyTogether.Data.Data;
using BuyTogether.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BuyTogether.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db) { }

        public async Task<Product?> GetBySlugAsync(string slug)
        {
            return await _db.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Slug == slug && p.IsActive);
        }

        public async Task<IEnumerable<Product>> GetTopAsync(int count)
        {
            return await _db.Products
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToListAsync();
        }
    }
}