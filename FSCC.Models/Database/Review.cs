using System.ComponentModel.DataAnnotations.Schema;

namespace FSCC.Models.Database
{
    [Table("Review")]
    public class Review : Entity.Entity
    {
        public int ItemId { get; set; }
        public string ReviewText { get; set; }
        public int ReviewScore { get; set; }
    }
}
