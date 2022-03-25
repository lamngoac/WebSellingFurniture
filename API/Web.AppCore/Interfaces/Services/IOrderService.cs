using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<int> InsertOrder(Order order, List<OrderDetail> orderDetails);
    }
}
