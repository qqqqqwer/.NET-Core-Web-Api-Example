using System;
using System.Collections.Generic;
using System.Text;

namespace FSCC.Models.Responses
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ReviewText { get; set; }
        public int ReviewScore { get; set; }
    }
}
