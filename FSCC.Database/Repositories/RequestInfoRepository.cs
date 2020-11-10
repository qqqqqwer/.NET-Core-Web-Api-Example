using FSCC.Database.Repositories.Abstractions;
using FSCC.Models.Database;

namespace FSCC.Database.Repositories
{
    public class RequestInfoRepository : GenericRepository<RequestInfo>, IRequestInfoRepository
    {
        public RequestInfoRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
