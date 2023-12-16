using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class ProductRelated
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductRelatedId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
