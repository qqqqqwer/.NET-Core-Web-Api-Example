using FSCC.Database.Repositories.Abstractions;
using FSCC.Models.Database;

namespace FSCC.Database.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DatabaseContext databaseContext) : base(databaseContext) { } 
    }
}
