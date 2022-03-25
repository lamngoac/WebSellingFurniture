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
    public class NewsController : BaseController<News>
    {
        #region Property
        INewsService _newsService;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo contructor
        /// </summary>
        public NewsController(INewsService newsService) : base(newsService)
        {
            _newsService = newsService;
        }
        [HttpGet("data-product")]
        public async Task<IActionResult> GetDataNewsProduct()
        {
            // Danh sách khách hàng
            var entities = await _newsService.GetDataNewsProduct();

            // Danh sách chứa đối tượng
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("data-sale")]
        public async Task<IActionResult> GetDataNewsSale()
        {
            // Danh sách khách hàng
            var entities = await _newsService.GetDataNewsSale();

            // Danh sách chứa đối tượng
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("data-event")]
        public async Task<IActionResult> GetDataNewsEvent()
        {
            // Danh sách khách hàng
            var entities = await _newsService.GetDataNewsEvent();

            // Danh sách chứa đối tượng
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }
        #endregion
    }
}
