using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class Review
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int? Star { get; set; }
        public string? Content { get; set; }
        /// <summary>
        /// 10: Chờ duyệt
        /// 20: Đã duyệt
        /// 30: Cập nhật lại - Chờ duyệt
        /// </summary>
        public int Status { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
