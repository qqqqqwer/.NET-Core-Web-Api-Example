using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FSCC.Models.Database
{
    [Table("RequestInformation")]
    public class RequestInfo : Entity.Entity
    {
        public string HttpMethodUsed { get; set; }
        public string EndPointUsed { get; set; }
    }
}
