using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    public class CartDetail
    {
        /// <summary>
        /// KHóa chính Id
        /// </summary>
        public Guid CartDetailId { get; set; }
        /// <summary>
        /// Id của sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// Id của giỏ hàng
        /// </summary>
        public Guid CardId { get; set; }
        /// <summary>
        /// Số lượng
        /// </summary>
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
