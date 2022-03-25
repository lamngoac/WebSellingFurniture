using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.Api.Controllers
{
    public class OrderRequest
    {
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
