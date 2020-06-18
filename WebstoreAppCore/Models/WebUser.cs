using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class WebUser
    {
        public WebUser()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Userpass { get; set; }
        public string UserImagePath { get; set; }
        public string Addrase { get; set; }
        public int? PostCode { get; set; }
        public int? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AccountSatet { get; set; }
        public int? NoOfAccess { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? NoOfBlock { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
