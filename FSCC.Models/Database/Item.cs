using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSCC.Models.Database
{
    [Table("Item")]
    public class Item : Entity.Entity
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
