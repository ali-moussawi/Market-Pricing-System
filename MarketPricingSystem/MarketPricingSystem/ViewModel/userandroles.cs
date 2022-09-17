using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPricingSystem.ViewModel
{
    public class Userandroles
    {


        public Users    User { get; set; }

        public IEnumerable<MarketPricingSystem.Models.Roles> Rolelist { get; set; }
    }
}