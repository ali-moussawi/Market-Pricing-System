using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class Userpermissions
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public virtual Permissions Permission { get; set; }
        public virtual Users User { get; set; }
    }
}
