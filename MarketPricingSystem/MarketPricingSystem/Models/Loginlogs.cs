using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Loginlogs
    {
        public int LogId { get; set; }
        public string UserGmail { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
