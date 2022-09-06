using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Supermarket
    {
        public Supermarket()
        {
            Productprices = new HashSet<Productprices>();
            Usersphonenumber = new HashSet<Usersphonenumber>();
        }

        public int SupermarketId { get; set; }
        public string SupermarketName { get; set; }
        public string SupermarketRegion { get; set; }
        public string SupermarketDescription { get; set; }

        public virtual ICollection<Productprices> Productprices { get; set; }
        public virtual ICollection<Usersphonenumber> Usersphonenumber { get; set; }
    }
}
