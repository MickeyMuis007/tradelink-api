﻿using System;
using System.Collections.Generic;

namespace Tradelink.Persistence.Models
{
    public partial class Users
    {
        public Users()
        {
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public ulong Enabled { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

    }
}
