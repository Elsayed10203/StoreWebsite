using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class UsersEmailsLogin
    {
        public int? UserId { get; set; }
        public string Email { get; set; }

        public virtual WebUser User { get; set; }
    }
}
