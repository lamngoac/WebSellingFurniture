using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    public class Filter
    {
        #region Property
        /// <summary>
        /// Trang hiện tại.
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// Số khách hàng trên một trang.
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Lọc theo tên
        /// </summary>
        public string Fil { get; set; } = "";

        #endregion
    }
}
