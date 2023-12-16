using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class User
    {
        public string UserName { get; set; } = null!;
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }
    }
}
