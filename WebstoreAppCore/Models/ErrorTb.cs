using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class ErrorTb
    {
        public int ErrId { get; set; }
        public string ErrMessage { get; set; }
        public DateTime ErrDate { get; set; }
        public string ErrPageName { get; set; }
        public int? ErrLine { get; set; }
        public string ErrDetails { get; set; }
    }
}
