using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Services;
namespace Web.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class OrderController : BaseController<Order>
    {
        #region Property
        IOrderService _orderService;
        IOrderDetailService _orderDetailService;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo contructor
        /// </summary>
        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService) : base(orderService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        #endregion

        [HttpPost("order-payment")]
        public async Task<IActionResult> InsertOrderAysnc([FromBody] OrderRequest request)
        {
            var res = await _orderService.InsertOrder(request.Order, request.OrderDetail);
            // Số bản ghi thêm được > 0
            if (res > 0)
            {
                return StatusCode(201, res);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("order-history/{UserId}")]
        public async Task<ActionResult<Pagging<HistoryOrderRespone>>> GetHistoryOrderByUserId(Guid UserId, [FromQuery] int PageIndex = 1, [FromQuery] int PageSize = 10)
        {
            var orders = new List<Order>();
            orders = (List<Order>)await _orderService.GetAll();
            orders = orders.Where(x => x.UserId == UserId).ToList();
            var histories = orders.Select(async x => new HistoryOrderRespone(x, (List<OrderDetail>)await _orderDetailService.GetOrderDetailByIdAsync((Guid)x.OrderId))).ToList();

            var result = histories.Skip(PageIndex).Take(PageSize);
            var pageResult = new Pagging<HistoryOrderRespone>()
            {
                TotalRecord = histories.Count,
                TotalPages = histories.Count % PageSize == 0 ?((int)histories.Count/PageSize) 
                    :((int)histories.Count / PageSize + 1),
                Data = histories.Select(x => x.Result).Take(PageSize).Skip(PageIndex-1).ToList().OrderByDescending(x=>x.Order.ModifiedDate),
                PageIndex = PageIndex,
                PageSize = PageSize
            };
            // Số bản ghi thêm được > 0
            if (pageResult != null)
            {
                return StatusCode(200, pageResult);
            }
            else
            {
                return NoContent();
            }
        }



    }
}
