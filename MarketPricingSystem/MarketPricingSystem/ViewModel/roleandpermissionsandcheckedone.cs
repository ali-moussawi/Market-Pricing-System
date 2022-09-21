using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketPricingSystem.Models;

namespace MarketPricingSystem.ViewModel
{
    public class roleandpermissionsandcheckedone
    {
        public Roles role { get; set; }

        public List<Permissions> permissions { get; set; }

        public List<Permissions> checkedpermissions { get; set; }

    }
}