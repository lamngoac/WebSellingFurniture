using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    /// <summary>
    /// Các dự án của công ty đã làm
    /// Created NVHIEN : 9/8/2021
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Id khóa chính
        /// </summary>
        public Guid? ProjectId { get; set; }
        /// <summary>
        /// Tiêu đề dự án
        /// </summary>
        public string ProjectTitle { get; set; }
        /// <summary>
        /// Nội dung mô tả dự án 
        /// </summary>
        public string ProjectContent { get; set; }
        /// <summary>
        /// Link ảnh
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

        /// <summary>
        /// Hien thi home
        /// </summary>
        public int ProjectHome { get; set; }
        /// <summary>
        /// Hien thi hot
        /// </summary>
        public int ProjectHot { get; set; }
    }
}
