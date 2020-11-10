using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSCC.Models.Responses
{
    public class ItemResponse
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public IEnumerable<ReviewResponse> ItemReviews {get; set;} 
    }
}
