using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AppCore.Entities
{
    public class SortCondition
    {
        /// <summary>
        /// Trạng thái sắp xếp
        /// </summary>
        public SortStatus SortStatus { get; set; } = SortStatus.None;
        /// <summary>
        /// Field Sắp xếp
        /// </summary>
        public string FieldSort { get; set; }
    }
}
