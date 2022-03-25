using System;
using System.Collections.Generic;
using System.Text;
using Web.AppCore.Enum;

namespace Web.AppCore.Entities
{
    public class Order
    {
        /// <summary>
        /// Id khách hàng
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public Guid? OrderId { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Thời gian sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Họ tên nhận hàng
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// địa chỉ nhận hàng
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// PT thanh toán
        /// </summary>
        public PaymentMethods PaymentMethods { get; set; } = PaymentMethods.Cash;
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public int StatusOrder { get; set; }

    }
}
