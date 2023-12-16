using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string Code { get; set; } = null!;
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Avatar { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Otp { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
