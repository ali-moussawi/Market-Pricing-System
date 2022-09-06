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
            Usergmails = new HashSet<Usergmails>();
            Userpermissions = new HashSet<Userpermissions>();
            Userroles = new HashSet<Userroles>();
            Usersphonenumber = new HashSet<Usersphonenumber>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Usergmails> Usergmails { get; set; }
        public virtual ICollection<Userpermissions> Userpermissions { get; set; }
        public virtual ICollection<Userroles> Userroles { get; set; }
        public virtual ICollection<Usersphonenumber> Usersphonenumber { get; set; }
    }
}
