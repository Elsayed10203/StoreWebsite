﻿using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class UserFavorites
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
        public virtual WebUsers User { get; set; }
    }
}
