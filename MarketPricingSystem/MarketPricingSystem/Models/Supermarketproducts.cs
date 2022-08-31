using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Supermarketproducts
    {
        public int SuperMarketId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Products Product { get; set; }
        public virtual Supermarket SuperMarket { get; set; }
    }
}
