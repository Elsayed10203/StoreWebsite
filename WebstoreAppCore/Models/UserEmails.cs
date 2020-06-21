using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class UserEmails
    {
        public int UserId { get; set; }
        public string Email { get; set; }

        public virtual WebUsers User { get; set; }
    }
}
