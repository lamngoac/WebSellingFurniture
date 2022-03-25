using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.AppCore.Enum
{
    public enum Gender
    {
        /// <summary>
        /// Enum định nghĩa giới tính Nam
        /// </summary>
        Male = 0,
        /// <summary>
        /// Enum định nghĩa giới tính nữ
        /// </summary>
        Famale = 1,
        /// <summary>
        /// Enum định nghĩa giới tính khác
        /// </summary>
        Other = 2,
    }
    public enum PaymentMethods
    {
        /// <summary>
        /// Chuyển khoản
        /// </summary>
        Transfer = 0,
        /// <summary>
        /// Tiền mặt, thanh toán khi nhận hàng
        /// </summary>
        Cash = 1,
    }
}
