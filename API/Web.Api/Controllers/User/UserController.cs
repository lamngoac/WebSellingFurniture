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
    public class UserController : BaseController<User>
    {
        #region Property
        IUserService _userService;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo contructor
        /// </summary>
        public UserController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Lấy thông tin  đối tượng theo id 
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns>
        /// HttpStatusCode 200 - có dữ liệu trả về
        /// HttpStatusCode 204 - không có dữ liệu
        /// </returns>
        [HttpGet("username")]
        public async Task<IActionResult> GetById([FromQuery] string userName)
        {
            var user = await _userService.GetUserByUserName(userName);
            //4. Kiểm tra dữ liệu : 
            //- Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            //- Nếu không có dữ liệu trả về 204
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NoContent();
            }
        }
        #endregion
    }
}
