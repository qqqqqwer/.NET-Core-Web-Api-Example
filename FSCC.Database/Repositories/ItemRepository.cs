using FSCC.Database.Repositories.Abstractions;
using FSCC.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSCC.Database.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public override async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _dbContext.Items
                .Include(e => e.Reviews)
                .ToListAsync();
        } 
    }
}
