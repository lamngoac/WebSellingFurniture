using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    public class Contact
    {
        /// <summary>
        /// Id khóa chính
        /// </summary>
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactReminder { get; set; }
        ///   /// <summary>
        ///  Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Thời gian sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
