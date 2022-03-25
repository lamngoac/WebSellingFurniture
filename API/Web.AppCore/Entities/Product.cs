using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    /// <summary>
    /// Sản phẩm
    /// Created BY : NVHIEN 9/8/2021
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id khóa chính
        /// </summary>
        public Guid? ProductId { get; set; }
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Kích thước sản phẩm
        /// </summary>
        public string ProductDimensions { get; set; }
        /// <summary>
        /// Chất liệu
        /// </summary>
        public string ProductMaterial { get; set; }
        /// <summary>
        /// Nhà cung cấp
        /// </summary>
        public string ProductManufacturer { get; set; }

        /// <summary>
        /// Màu chủ đạo sản phẩm
        /// </summary>
        public int ProductColor { get; set; }

        /// <summary>
        /// Giá gốc
        /// </summary>
        public decimal ProductOriginalPrice { get; set; }

        /// <summary>
        /// Giá sale
        /// </summary>
        public decimal ProductSalePrice { get; set; }

        /// <summary>
        /// Mô tả ngắn về sản phẩm
        /// </summary>
        public string ProductDescriptionShort { get; set; }

        /// <summary>
        /// Mô tả chi tiết về sản phẩm
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Đánh giá của sản phẩm
        /// </summary>
        public decimal ProductEvaluate { get; set; }
        /// <summary>
        ///  Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Thời gian sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// id danh muc san pham
        /// </summary>
        public Guid ProductCategoryId { get; set; }
        /// <summary>
        /// anh 
        /// </summary>
        public string ProductImage { get; set; }
    }
}
