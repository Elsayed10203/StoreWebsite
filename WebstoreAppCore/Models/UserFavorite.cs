using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class UserFavorite
    {
        public int? UserId { get; set; }
        public int? FavoriteCatag { get; set; }

        public virtual Category FavoriteCatagNavigation { get; set; }
        public virtual WebUser User { get; set; }
    }
}
