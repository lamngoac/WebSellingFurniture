using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.AppCore.Interfaces.Services;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class CartController : Controller
    {
        //private ICartService _cartService;
        //public CartController(ICartService cartService)
        //{
        //    _cartService = cartService;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetDataCartByCachedAsync([FromQuery] Guid userId)
        //{
        //    // Danh sách khách hàng
        //    var entities = await _cartService.GetCartByCachedAsync(userId);

        //    // Danh sách chứa đối tượng
        //    if (entities.Count() > 0)
        //    {
        //        return Ok(entities);
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}

    }
}
