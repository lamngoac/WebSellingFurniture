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
    public class ProductController : BaseController<Product>
    {
        #region Property
        IProductService _productService;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo contructor
        /// </summary>
        public ProductController(IProductService productService) : base(productService)
        {
            _productService = productService;
        }

        [HttpGet("pagging-product")]
        public async Task<IActionResult> GetPaggingProductAsync([FromQuery] Filter filter, [FromQuery] string sort = "", [FromQuery] string categoryId = "", [FromQuery] int price = 0)

        {
            var paging = await _productService.GetProductPaggingAsync(filter, sort,categoryId, price);

            // Xử lý kết quả trả về cho client.
            if (paging.Data.Any() && filter.PageIndex >= 0 && filter.PageSize >= 0)
            {
                return Ok(paging);
            }
            return NoContent();
        }
        [HttpGet("top-selling")]
        public async Task<IActionResult> GetProductsTopSellingAsync([FromQuery] int number = 1)

        {
            var res = await _productService.GetProductsTopSelling(number);
            // Xử lý kết quả trả về cho client.
            if (res != null)
            {
                return Ok(res);
            }
            return NoContent();
        }

        #endregion
    }
}
