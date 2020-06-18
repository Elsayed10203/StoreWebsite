using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class ErrorTb
    {
        public int ErrId { get; set; }
        public string ErrorMessag { get; set; }
        public DateTime? ErrorDate { get; set; }
        public string PageName { get; set; }
        public int? ErrorLine { get; set; }
        public string ErrorDetails { get; set; }
    }
}
