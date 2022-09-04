using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Products
    {
        public Products()
        {
            Productprices = new HashSet<Productprices>();
            Supermarketproducts = new HashSet<Supermarketproducts>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BarcodeNb { get; set; }
        public string ProductDescription { get; set; }

        public virtual ICollection<Productprices> Productprices { get; set; }
        public virtual ICollection<Supermarketproducts> Supermarketproducts { get; set; }
    }
}
