using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Services;
using Web.Caching;

namespace Web.AppCore.Service
{
    public class CartService : ICartService
    {
        IRedisCached _cached;
        public CartService(IRedisCached cached)
        {
            _cached = cached;
        }
        public async Task<List<CartDetail>> GetCartByCachedAsync(Guid userId)
        {
            var cart = await _cached.GetAsync<Cart>(GetKeyCachedCart(userId));
            var list = await _cached.GetAsync<List<CartDetail>>(GetKeyCachedCartDetail(cart.CartId));
            return list;
        }
        public async Task<bool> UpdateCartCached(List<CartDetail> cartDetails, Guid userId)
        {
            try
            {
                var cart = await _cached.GetAsync<Cart>(GetKeyCachedCart(userId));
                var list = await _cached.GetAsync<List<CartDetail>>(GetKeyCachedCartDetail(cart.CartId));
                list = new List<CartDetail>();
                // Lưu cached 1 năm
                var timeCached = 60 * 60 * 24 * 365;
                // Reset data cached
                await _cached.SetAsync<List<CartDetail>>(GetKeyCachedCartDetail(cart.CartId), list, timeCached);
                list.AddRange(cartDetails);
                //thêm data cached
                await _cached.SetAsync<List<CartDetail>>(GetKeyCachedCartDetail(cart.CartId), list, timeCached);
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// Set cached phục vụ lưu trữ thông tin giỏ hàng
        /// </summary>
        /// <param name="userId">Id người dùng</param>
        /// <param name="cartId">Id giỏ hàng</param>
        /// <returns></returns>
        private string GetKeyCachedCart(Guid userId) { return $"{userId}"; }
        /// <summary>
        /// Set cached phục vụ lưu trữ chi tiết từng sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        private string GetKeyCachedCartDetail(Guid cartId) { return $"{cartId}"; }
    }
}
