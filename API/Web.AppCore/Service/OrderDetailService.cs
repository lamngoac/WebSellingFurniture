using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;

namespace Web.AppCore.Service
{
    public class OrderDetailService : BaseService<OrderDetail>, IOrderDetailService
    {
        IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository) : base(orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByIdAsync(Guid OrderId)
        {
            return await _orderDetailRepository.GetOrderDetailByIdAsync(OrderId);
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(Guid orderId)
        {
            var orderDeteails = await _orderDetailRepository.GetAll();
            orderDeteails = orderDeteails.Where(o => o.OrderId == orderId);
            return orderDeteails;
        }

    }
}
