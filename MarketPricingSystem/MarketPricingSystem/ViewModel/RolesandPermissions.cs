using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketPricingSystem.Models;
namespace MarketPricingSystem.ViewModel
{
    public class RolesandPermissions
    {
        Roles Role { get; set; }
        
        IEnumerable<Permissions> Permissions { get; set; }


    }
}