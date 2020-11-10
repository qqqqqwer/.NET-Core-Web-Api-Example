using FSCC.Models.Requests;
using FSCC.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FSCC.Controllers
{
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IReviewService _reviewService;
        private readonly IRequestInfoService _requestInfoService;
        public ItemsController(IItemService itemService, IReviewService reviewService, IRequestInfoService requestInfoService)
        {
            _requestInfoService = requestInfoService;
            _reviewService = reviewService;
            _itemService = itemService;
        }


        [HttpGet("items")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            return new OkObjectResult(items);
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddItem([FromBody]CreateItemRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Select(x => x.Value.Errors)
                    .Where(x => x.Count > 0)
                    .ToList()); 
            
            var addedItem = await _itemService.AddItemAsync(request);
            return new OkObjectResult(addedItem);
        }

        [HttpPost("items/review")]
        public async Task<IActionResult> AddReview([FromBody]CreateReviewRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Select(x => x.Value.Errors)
                        .Where(x => x.Count > 0)
                        .ToList());

            var review = await _reviewService.CreateReviewAsync(request);
            return new OkObjectResult(review);
        }

    }
}
