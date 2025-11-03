using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTogether.Core.Entities;

namespace BuyTogether.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllActiveAsync(string? search = null);
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetBySlugAsync(string slug);
    }
}
