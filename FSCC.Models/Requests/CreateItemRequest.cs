using System.ComponentModel.DataAnnotations;

namespace FSCC.Models.Requests
{
    public class CreateItemRequest
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}
