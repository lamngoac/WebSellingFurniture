using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    /// <summary>
    /// Tuyển dụng
    /// Created NVHIEN 9/8/2021
    /// </summary>
    public class Recruitment
    {
        /// <summary>
        ///  Id khóa chính
        /// </summary>
        public Guid RecruitmentId { get; set; }

        /// <summary>
        /// Nội dung tuyển dụng
        /// </summary>
        public string RecruitmentContent { get; set; }
        /// <summary>
        /// Tiêu đề tuyển dụng
        /// </summary>
        public string RecruitmentTitle { get; set; }
        /// <summary>
        /// Link ảnh
        /// </summary>
        public string LinkImage { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Thời gian sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Hien thi home
        /// </summary>
        public int RecruitmentHome { get; set; }
        /// <summary>
        /// Hien thi hot
        /// </summary>
        public int RecruitmentHot { get; set; }
    }
}
