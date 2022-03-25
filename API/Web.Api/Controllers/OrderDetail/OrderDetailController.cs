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
    public class OrderDetailController : BaseController<OrderDetail>
    {
        #region Property
        IOrderDetailService _orderDetailService;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo contructor
        /// </summary>
        public OrderDetailController(IOrderDetailService orderDetailService) : base(orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        #endregion

        #region Methods
        
        #endregion
    }
}
