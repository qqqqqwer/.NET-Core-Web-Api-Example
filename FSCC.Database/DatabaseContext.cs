using FSCC.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace FSCC.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<RequestInfo> RequestInformation { get; set; }
    }
}
