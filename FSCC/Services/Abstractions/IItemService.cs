using FSCC.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using FSCC.Models.Requests;

namespace FSCC.Services.Abstractions
{
    public interface IItemService
    {
        Task<IEnumerable<ItemResponse>> GetAllItemsAsync();
        Task<ItemResponse> AddItemAsync(CreateItemRequest request); 
    }
}
