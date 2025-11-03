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
    public class GroupDealRepository : GenericRepository<GroupDeal>, IGroupDealRepository
    {
        public GroupDealRepository(ApplicationDbContext db) : base(db) { }

        public async Task<IEnumerable<GroupDeal>> GetActiveDealsAsync()
        {
            var now = DateTime.UtcNow;
            return await _db.GroupDeals
                .Include(g => g.Product)
                .Where(g => g.Status == "Active" && g.StartAt <= now && g.EndAt >= now)
                .ToListAsync();
        }

        public async Task<GroupDeal?> GetWithMembersAsync(int id)
        {
            return await _db.GroupDeals
                .Include(g => g.Members)
                .Include(g => g.Product)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
