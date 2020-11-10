using System.ComponentModel.DataAnnotations;

namespace FSCC.Models.Requests
{
    public class CreateReviewRequest
    {
        [Required(ErrorMessage = "Item id is required")]
        public int ItemId { get; set; }
        public string ReviewText { get; set; }

        [Required(ErrorMessage = "Review score is required")]
        [Range(1, 5)]
        public int ReviewScore { get; set; }
    }
}
