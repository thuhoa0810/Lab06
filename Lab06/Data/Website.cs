using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class Website
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? Copyright { get; set; }
    }
}
