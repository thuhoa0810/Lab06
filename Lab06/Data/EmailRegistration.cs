using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class EmailRegistration
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public DateTime Created { get; set; }
    }
}
