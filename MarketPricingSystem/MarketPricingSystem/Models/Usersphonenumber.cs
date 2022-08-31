using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Usersphonenumber
    {
        public int? UserId { get; set; }
        public int? SuperMarketId { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Supermarket SuperMarket { get; set; }
        public virtual Users User { get; set; }
    }
}
