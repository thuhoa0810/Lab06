using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? CustomerCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public double? TotalAmount { get; set; }
        /// <summary>
        /// 10: Chờ xác nhận
        /// 20: Đã xác nhận
        /// 30: Đang vận chuyển
        /// 40: Đã giao
        /// 50: Đã hủy
        /// </summary>
        public int Status { get; set; }
        public string? Note { get; set; }
        public DateTime Created { get; set; }

        public virtual Customer? CustomerCodeNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
