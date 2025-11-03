using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTogether.Core.Entities;

namespace BuyTogether.Data.Interfaces
{
    public interface IGroupDealRepository : IRepository<GroupDeal>
    {
        Task<IEnumerable<GroupDeal>> GetActiveDealsAsync();
        Task<GroupDeal?> GetWithMembersAsync(int id);
    }
}
