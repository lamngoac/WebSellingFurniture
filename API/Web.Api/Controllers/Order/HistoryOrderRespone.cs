using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.Api.Controllers
{
    public class HistoryOrderRespone 
    {
        public HistoryOrderRespone(Order order, IEnumerable<OrderDetail> orderDetails)
        {
            this.Order = order;
            this.OrderDetails = orderDetails;
        }
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
