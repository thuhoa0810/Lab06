using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class Product
    {
        public Product()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
            ProductImages = new HashSet<ProductImage>();
            ProductRelateds = new HashSet<ProductRelated>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string? Image { get; set; }
        public int? Index { get; set; }
        /// <summary>
        /// 10: Đang bán
        /// 20: Dừng bán
        /// 30: Hết hàng
        /// </summary>
        public int? Status { get; set; }
        public double? Price { get; set; }
        public double? DiscountPrice { get; set; }
        public bool? Selling { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }

        public virtual Menu Menu { get; set; } = null!;
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductRelated> ProductRelateds { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
