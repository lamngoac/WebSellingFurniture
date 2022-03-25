using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    /// <summary>
    /// Danh mục sản phẩm 
    /// Created By : NVHIEN 9/8/2021
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Id khóa chính
        /// </summary>
        public Guid ProductCategoryId { get; set; }
        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string ProductCategoryName { get; set; }
        /// <summary>
        /// Mô tả danh mục
        /// </summary>
        public string ProductCategoryDescription { get; set; }
        /// <summary>
        ///  Thời gian tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Thời gian sửa đổi
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Link anh 
        /// </summary>
        public string ProductCategoryImage{ get; set; }
        /// <summary>
        /// Hien thi home
        /// </summary>
        public int ProductCategoryHome { get; set; }
    }
}
