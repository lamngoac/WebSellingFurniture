using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    /// <summary>
    /// Tin tức 
    /// Created BY : NVHIEN 9/8/2021
    /// </summary>
    public class News
    {
        /// <summary>
        /// Id khóa chính
        /// </summary>
        public Guid? NewsId { get; set; }
        /// <summary>
        /// Tiêu đề tin tức
        /// </summary>
        public string NewsTitle { get; set; }
        /// <summary>
        /// Nội dung tin tức
        /// </summary>
        public string NewsContent { get; set; }
        /// <summary>
        /// Tin hot
        /// </summary>
        public int NewsHot { get; set; }
        /// <summary>
        /// Tin tức về sản phẩm
        /// </summary>
        public int NewsProduct { get; set; }
        /// <summary>
        /// Tin tực sale
        /// </summary>
        public int NewsSale { get; set; }
        /// <summary>
        /// Tin tức về sự kiện
        /// </summary>
        public int NewsEvent { get; set; }
        /// <summary>
        /// Link image
        /// </summary>
        public int NewsHome { get; set; }
        /// <summary>
        /// Link image
        /// </summary>
        public string LinkImage { get; set; }

        /// <summary>
        ///  Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Thời gian sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
