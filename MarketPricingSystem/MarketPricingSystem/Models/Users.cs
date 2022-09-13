using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Users
    {
        public Users()
        {
            Userroles = new HashSet<Userroles>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Userroles> Userroles { get; set; }
    }
}
