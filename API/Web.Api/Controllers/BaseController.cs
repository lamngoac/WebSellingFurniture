using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Enum;
using Web.AppCore.Interfaces.Services;

namespace Web.Api.Controllers
{
    /// <summary>
    /// Controller dùng chung
    /// </summary>
    /// <typeparam name="T"></typeparam>
    
    public class BaseController<T> : Controller where T:class
    {
        #region Property
        IBaseService<T> _baseService;
        #endregion

        #region Contructor
        //Contructor  
        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion


        #region Methods 

        /// <summary>
        /// Thông tin danh sách đối tượng
        /// </summary>
        /// <returns>
        /// HttpStatusCode 200 - có dữ liệu trả về
        /// HttpStatusCode 204 - không có dữ liệu
        /// Thông tin danh sách đối tượng
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Danh sách khách hàng
            var entities = await _baseService.GetAll();

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

        [HttpGet("data-home")]
        public async Task<IActionResult> GetHome()
        {
            // Danh sách khách hàng
            var entities = await _baseService.GetDataHome();

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

        [HttpGet("data-hot")]
        public async Task<IActionResult> GetHot()
        {
            // Danh sách khách hàng
            var entities = await _baseService.GetDataHot();

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
        /// <summary>
        /// Lấy thông tin  đối tượng theo id 
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns>
        /// HttpStatusCode 200 - có dữ liệu trả về
        /// HttpStatusCode 204 - không có dữ liệu
        /// </returns>
        [HttpGet("{entityId}")]
        public async Task<IActionResult> GetById(Guid entityId)
        {
            var entity = await _baseService.GetById(entityId);
            //4. Kiểm tra dữ liệu : 
            //- Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            //- Nếu không có dữ liệu trả về 204
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }


        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng thêm mới</param>
        /// <returns>
        /// 201- thêm mới thành công
        /// 204 - không thêm được vào db
        /// 400 - dữ liệu đầu vào không hợp lệ
        /// 500 - có lối xả ra phía server (exception,...)
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            var res = await _baseService.Insert(entity);
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
        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <param name="entityId">id đối tượng</param>
        /// <returns>
        /// HttpStatusCode 200 - có dữ liệu trả về
        /// HttpStatusCode 204 - không có dữ liệu
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] T entity)
        {
            var rowAffects = await _baseService.Update(entity);
            // số bản ghi được sửa đổi
            if (rowAffects > 0)
            {
                return StatusCode(201, "Thành công");
            }
            return NoContent();
        }

        /// <summary>
        /// Xóa thông tin  đối tượng
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns>
        /// 200 - Xóa thành công
        /// 204 - Không xóa được dữ liệu khỏi DB 
        /// </returns>
        [HttpDelete("{entityId}")]
        public async Task<IActionResult> Delete(Guid entityId)
        {
            var rowAffects = await _baseService.Delete(entityId);
            if (rowAffects > 0)
            {
                return Ok("Xóa thành công");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("pagging")]
        public async Task<IActionResult> GetSuppliers([FromQuery] Filter filter, [FromQuery] string sort="")
        {
            var paging = await _baseService.GetPaggingAsync(filter, sort);

            // Xử lý kết quả trả về cho client.
            if (paging.Data.Any() && filter.PageIndex >= 0 && filter.PageSize >= 0)
            {
                return Ok(paging);
            }
            return NoContent();
        }
        #endregion
    }
}
