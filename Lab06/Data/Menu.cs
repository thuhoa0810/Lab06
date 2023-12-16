using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class Menu
    {
        public Menu()
        {
            Articles = new HashSet<Article>();
            InverseParentMenuNavigation = new HashSet<Menu>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? ParentMenu { get; set; }
        public string Name { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public int? Index { get; set; }
        public bool? ShowHomePage { get; set; }
        public string? Type { get; set; }
        public bool Active { get; set; }

        public virtual Menu? ParentMenuNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Menu> InverseParentMenuNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
