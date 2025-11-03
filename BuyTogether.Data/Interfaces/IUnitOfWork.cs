using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTogether.Core.Entities;

namespace BuyTogether.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IGroupDealRepository GroupDeals { get; }
        Task<int> SaveChangesAsync();
    }
}