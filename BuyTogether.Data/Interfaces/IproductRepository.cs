using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTogether.Core.Entities;

namespace BuyTogether.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetBySlugAsync(string slug);
        Task<IEnumerable<Product>> GetTopAsync(int count);
    }
}
