using System.ComponentModel.DataAnnotations;

namespace FSCC.Models.Requests
{
    public class CreateItemRequest
    {
        [Required(ErrorMessage = "Item Name is required")]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}
