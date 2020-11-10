using FSCC.Models.Requests;
using FSCC.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FSCC.Controllers
{
    public class ReviewsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IReviewService _reviewService;
        private readonly IRequestInfoService _requestInfoService;

        public ReviewsController(IItemService itemService, IReviewService reviewService, IRequestInfoService requestInfoService)
        {
            _requestInfoService = requestInfoService;
            _reviewService = reviewService;
            _itemService = itemService;
        }

        [HttpPost("reviews")]
        public async Task<IActionResult> AddReview([FromBody]CreateReviewRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Select(x => x.Value.Errors)
                        .Where(x => x.Count > 0)
                        .ToList());

            await _requestInfoService.RegisterInformation("Post", "/reviews");
            var review = await _reviewService.CreateReviewAsync(request);
            return new OkObjectResult(review);
        }

    }
}
