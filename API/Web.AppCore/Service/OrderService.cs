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
    public class OrderService : BaseService<Order>, IOrderService
    {
        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailRepository;
        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository):base(orderRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<int> InsertOrder(Order order, List<OrderDetail> orderDetails)
        {
            return await _orderRepository.InsertOrder(order, orderDetails);
        }
    }
}
