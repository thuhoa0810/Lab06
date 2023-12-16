using System;
using System.Collections.Generic;

namespace Lab06.Data
{
    public partial class EmailTemplate
    {
        public int Id { get; set; }
        /// <summary>
        /// 1: WAITING_FOR_REVIEW. 
        /// 2: WAITING_FOR_APPROVAL. 
        /// 3: READY_TO_SEND_TO_CUSTOMER. 
        /// 4: QUOTATION_IS_NEARLY_INVALID.
        /// </summary>
        public string Type { get; set; } = null!;
        public string? Subject { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public string KeyGuide { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
