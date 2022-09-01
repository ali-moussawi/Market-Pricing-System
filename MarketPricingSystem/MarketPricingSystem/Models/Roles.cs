using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Rolepermissions = new HashSet<Rolepermissions>();
            Userroles = new HashSet<Userroles>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Rolepermissions> Rolepermissions { get; set; }
        public virtual ICollection<Userroles> Userroles { get; set; }
    }
}
