using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
