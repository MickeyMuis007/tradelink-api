﻿using System;
using System.Collections.Generic;

namespace Tradelink.Persistence.Models
{
    public partial class UserRole
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Users User { get; set; }
    }
}
