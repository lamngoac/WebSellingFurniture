using System;

namespace Web.AppCore.Entities
{
    public class User
    {
        /// <summary>
        /// Id người dùng
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        ///  Tên tài khoản
        /// </summary>
        /// 
        public string UserName { get; set; }
        /// <summary>
        ///  Mật khẩu
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        
        public string FullName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// quyen
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Thời gian sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
