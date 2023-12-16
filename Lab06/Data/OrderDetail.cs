using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductImage { get; set; }
        public double? ProductPrice { get; set; }
        public double? ProductDiscountPrice { get; set; }
        public int? Qty { get; set; }
        public string? Attribute { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
