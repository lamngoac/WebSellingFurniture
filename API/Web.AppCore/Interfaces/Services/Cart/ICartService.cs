using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Services
{
    public interface ICartService
    {
        /// <summary>
        /// Danh danh sách chi tiết đơn hàng từ Cached
        /// </summary>
        /// <returns></returns>
        Task<List<CartDetail>> GetCartByCachedAsync(Guid userId);

        /// <summary>
        /// Lấy đơn hàng theo UserId
        /// </summary>
        /// <returns></returns>
        //Task<Cart> GetCartByUser(Guid userId);

        Task<bool> UpdateCartCached(List<CartDetail> cartDetails, Guid userId);
    }
}
