using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTogether.Services.Interfaces;
using BuyTogether.Data.Interfaces;
using BuyTogether.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuyTogether.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        public ProductService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<Product>> GetAllActiveAsync(string? search = null)
        {
            var query = _uow.Products.Query().Where(p => p.IsActive);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p => p.Title.Contains(search) || p.Description.Contains(search));

            return await query
                .Include(p => p.Category)
                .Include(p => p.Images)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _uow.Products.Query()
                .Include(p => p.Images)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<Product?> GetBySlugAsync(string slug)
        {
            return await _uow.Products.GetBySlugAsync(slug);
        }
    }
}