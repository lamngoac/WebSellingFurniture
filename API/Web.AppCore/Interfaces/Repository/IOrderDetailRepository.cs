using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Repository
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailByIdAsync(Guid OrderId);
    }
}
