using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class WebUsers
    {
        public WebUsers()
        {
            Orders = new HashSet<Orders>();
            UserEmails = new HashSet<UserEmails>();
            UserFavorites = new HashSet<UserFavorites>();
            UserProductComments = new HashSet<UserProductComments>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserImagePath { get; set; }
        public string Address { get; set; }
        public int PostCode { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsOnline { get; set; }
        public int NoOfAccess { get; set; }
        public DateTime CreationDate { get; set; }
        public int NoOfBlock { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<UserEmails> UserEmails { get; set; }
        public virtual ICollection<UserFavorites> UserFavorites { get; set; }
        public virtual ICollection<UserProductComments> UserProductComments { get; set; }
    }
}
