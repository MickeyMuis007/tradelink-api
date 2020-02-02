using System;
using System.Collections.Generic;

namespace Tradelink.Persistence.Models
{
    public partial class Authorities
    {
        public long Id { get; set; }
        public string Authority { get; set; }
        public string Username { get; set; }
    }
}
