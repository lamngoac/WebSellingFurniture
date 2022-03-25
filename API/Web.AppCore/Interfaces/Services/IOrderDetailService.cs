using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Services
{
    public interface IOrderDetailService  :IBaseService<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailByIdAsync(Guid OrderId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(Guid orderId);
    }


}
