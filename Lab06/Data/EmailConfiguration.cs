using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class EmailConfiguration
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
