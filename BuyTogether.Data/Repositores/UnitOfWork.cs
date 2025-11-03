using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTogether.Core.Entities;
using BuyTogether.Data.Data;
using BuyTogether.Data.Interfaces;

namespace BuyTogether.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IProductRepository? _productRepo;
        private IGroupDealRepository? _groupDealRepo;

        public UnitOfWork(ApplicationDbContext db) => _db = db;

        public IProductRepository Products => _productRepo ??= new ProductRepository(_db);
        public IGroupDealRepository GroupDeals => _groupDealRepo ??= new GroupDealRepository(_db);

        public async Task<int> SaveChangesAsync() => await _db.SaveChangesAsync();

        public void Dispose() => _db.Dispose();
    }
}
