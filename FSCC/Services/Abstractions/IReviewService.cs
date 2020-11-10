using FSCC.Models.Requests;
using FSCC.Models.Responses;
using System.Threading.Tasks;

namespace FSCC.Services.Abstractions
{
    public interface IReviewService
    {
        Task<ReviewResponse> CreateReviewAsync(CreateReviewRequest request);
    }
}
