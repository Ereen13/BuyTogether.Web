using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuyTogether.Data.Data;
using BuyTogether.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BuyTogether.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _db;
        public GenericRepository(ApplicationDbContext db) => _db = db;

        public async Task AddAsync(T entity) => await _db.Set<T>().AddAsync(entity);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _db.Set<T>().Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync() => await _db.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _db.Set<T>().FindAsync(id);

        public void Remove(T entity) => _db.Set<T>().Remove(entity);

        public void Update(T entity) => _db.Set<T>().Update(entity);

        public IQueryable<T> Query() => _db.Set<T>().AsQueryable();
    }
}