using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Supermarket
    {
        public int SupermarketId { get; set; }
        public string SupermarketName { get; set; }
        public string SupermarketRegion { get; set; }
        public string SupermarketDescription { get; set; }
        public string Phonenumber { get; set; }
    }
}
