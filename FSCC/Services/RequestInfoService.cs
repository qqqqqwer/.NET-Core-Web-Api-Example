using FSCC.Database.Repositories;
using FSCC.Database.Repositories.Abstractions;
using FSCC.Models.Database;
using FSCC.Models.Requests;
using FSCC.Models.Responses;
using FSCC.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSCC.Services
{
    public class RequestInfoService : IRequestInfoService
    {
        IRequestInfoRepository requestInfoRepository;

        public async Task RegisterInformation(string method, string endpoint)
        {
            await requestInfoRepository.AddAsync(new RequestInfo() { HttpMethodUsed = method, EndPointUsed = endpoint } );
        }
    }
}
