using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    /// <summary>
    /// Chi tiết đơn hàng
    /// </summary>
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        /// <summary>
        /// Id đơn  hàng
        /// </summary>
        public Guid? OrderId { get; set; }
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        /// <summary>
        /// Số lượng
        /// </summary>
        public int Amount { get; set; }
    }
}
