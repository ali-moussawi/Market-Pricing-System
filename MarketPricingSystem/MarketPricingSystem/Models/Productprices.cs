using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Productprices
    {
        public int ProductId { get; set; }
        public int SupermarketId { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public int IsActivePrice { get; set; }
    }
}
