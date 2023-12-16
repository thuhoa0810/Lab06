using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class Attribute
    {
        public Attribute()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
