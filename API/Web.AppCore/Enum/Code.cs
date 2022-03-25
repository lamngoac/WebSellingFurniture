using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Enum
{
    public enum Code
    {
        /// <summary>
        /// Enum định nghĩa code lỗi mã nhân viên để trống
        /// </summary>
        CodeUserNameEmpty = 1,
        /// <summary>
        /// Enum định nghĩa code lỗi họ tên để trống
        /// </summary>
        CodeFullNameEmpty = 2,
        /// <summary>
        /// Enum định nghĩa code lỗi đơn vị để trống
        /// </summary>
        CodeDepartmentEmpty = 3,

        /// <summary>
        /// Enum định nghĩa code lỗi mã nhân viên trùng
        /// </summary>
        CodeEmployeeCodeExist = 4,


        /// <summary>
        /// Enum định nghĩa code định dạng email
        /// </summary>
        CodeEmailFormat = 5,

        /// <summary>
        /// Enum định nghĩa mã nhà cung cấp để trống
        /// </summary>
        CodeSupplierCodeEmpty = 6,

        /// <summary>
        /// Enum định nghĩa tên nhà cung cấp để trống
        /// </summary>
        CodeSupplierNameEmpty = 7,

        /// <summary>
        /// Enum định nghĩa code lỗi mã nhà cung cấp trùng
        /// </summary>
        CodeSupplierCodeExist = 8,

        /// <summary>
        /// Enum định nghĩa code lỗi số chứng từ trùng
        /// </summary>
        CodeVoucherNumberExist = 9,

        /// <summary>
        /// Enum định nghĩa code lỗi số tài khoản trùng
        /// </summary>
        CodeAccountNumberExist = 10,

        /// <summary>
        /// Enum định nghĩa code lỗi số tài khoản trùng
        /// </summary>
        CodeAccountNumberEmpty = 11,

        /// <summary>
        /// Enum định nghĩa code lỗi số tài khoản trùng
        /// </summary>
        CodeAccountNameEmpty = 12,

        /// <summary>
        /// Enum định nghĩa code lỗi số tài khoản tổng hợp không phù hợp định nghĩa (tài khoản tổng hợp = 3 kí tự)
        /// </summary>
        CodeGenneralAccountNumberFail = 13,

        /// <summary>
        /// Enum định nghĩa code lỗi số tài khoản con không phụ hợp tài khoản cha
        /// </summary>
        CodeAccountNumberChildFail = 14,
    }
    public enum CodeUser
    {
        /// <summary>
        /// Enum định nghĩa code user name để trống
        /// </summary>
        CodeUserNameEmpty = 1,
        /// <summary>
        /// Enum định nghĩa code mật khẩu để trống
        /// </summary>
        CodeUserPassEmpty = 2,

    }
}
