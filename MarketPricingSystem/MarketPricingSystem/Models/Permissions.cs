using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Permissions
    {
        public Permissions()
        {
            Rolepermissions = new HashSet<Rolepermissions>();
            Userpermissions = new HashSet<Userpermissions>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; }

        public virtual ICollection<Rolepermissions> Rolepermissions { get; set; }
        public virtual ICollection<Userpermissions> Userpermissions { get; set; }
    }
}
