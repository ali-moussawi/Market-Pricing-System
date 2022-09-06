using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Usergmails
    {
        public int UserId { get; set; }
        public string UserGmail { get; set; }
        public string Password { get; set; }

        public virtual Users User { get; set; }
    }
}
