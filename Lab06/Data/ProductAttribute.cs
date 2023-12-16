using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class ProductAttribute
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public string? Value { get; set; }

        public virtual Attribute Attribute { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
