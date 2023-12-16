using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class Gallery
    {
        public int Id { get; set; }
        public string Image { get; set; } = null!;
        public int Type { get; set; }
    }
}
