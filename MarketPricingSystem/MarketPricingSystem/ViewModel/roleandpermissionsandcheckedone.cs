using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MarketPricingSystem.Models;

namespace MarketPricingSystem.ViewModel
{
    public class roleandpermissionsandcheckedone
    {
        public MarketPricingSystem.Models.Roles role { get; set; } //target role

        public List<Permissions> permissions { get; set; }//all permissions

        public List<Rolepermissions> checkedpermissionsid { get; set; } //ids of permissions where roleid = roleid

    }
}