using FSCC.Database.Repositories.Abstractions;
using FSCC.Models.Database;
using FSCC.Models.Requests;
using FSCC.Models.Responses;
using FSCC.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSCC.Services
{
    public class ReviewService : IReviewService
    {
        IItemRepository _itemRepository;
        IReviewRepository _reviewRepository;

        public ReviewService(IItemRepository itemRepository, IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
            _itemRepository = itemRepository;
        }


        public async Task<ReviewResponse> CreateReviewAsync(CreateReviewRequest request)
        {
            var items = await _itemRepository.GetAllAsync();
            var foundItem = GetItemById(items, request.ItemId);

            if (foundItem == null)
                throw new KeyNotFoundException("Item with this id is not found.");

            var review = new Review()
            {
                ItemId = request.ItemId,
                ReviewScore = request.ReviewScore,
                ReviewText = request.ReviewText
            };

            var created = await _reviewRepository.AddAsync(review);

            var itemReviews = foundItem.Reviews;
            itemReviews.Add(created);
            foundItem.Reviews = itemReviews;

            await _itemRepository.UpdateAsync(foundItem);

            return MapReviewToResponse(created);
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

        private static Item GetItemById(IEnumerable<Item> items, int id)
        {
            foreach(var i in items)
                if (i.Id == id)
                    return i;

            return null;
        }  
    }
}
