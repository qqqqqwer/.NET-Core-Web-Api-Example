using FSCC.Database.Repositories.Abstractions;
using FSCC.Models.Database;
using FSCC.Models.Requests;
using FSCC.Models.Responses;
using FSCC.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSCC.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemResponse>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            var itemResponses = new List<ItemResponse>();

            foreach(var i in items)
                itemResponses.Add(MapItemToResponse(i));
            
            return itemResponses;
        }

        public async Task<ItemResponse> AddItemAsync(CreateItemRequest request)
        {
            var item = new Item()
            {
                ItemName = request.ItemName,
                ItemDescription = request.ItemDescription,
                Reviews = new List<Review>()
            };

            var created = await _itemRepository.AddAsync(item);

            return MapItemToResponse(created);
        }

        private static ItemResponse MapItemToResponse(Item item)
        {
            var mappedReviews = new List<ReviewResponse>();
            var itemReviews = item.Reviews;

            if (itemReviews != null)
                foreach (var r in itemReviews) 
                    mappedReviews.Add(MapReviewToResponse(r));

            return new ItemResponse()
            {
                Id = item.Id,
                ItemName = item.ItemName,
                ItemDescription = item.ItemDescription,
                ItemReviews = mappedReviews
            };
        }

        private static ReviewResponse MapReviewToResponse(Review review)
        {
            return new ReviewResponse()
            {
                Id = review.Id,
                ItemId = review.ItemId,
                ReviewScore = review.ReviewScore,
                ReviewText = review.ReviewText
            };
        }
    }
}
