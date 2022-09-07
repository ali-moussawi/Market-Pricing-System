using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPricingSystem.ViewModel
{
    public class signin
    {

        [Required]
        public string gmail { get; set; }

        [Required]
        public string password { get; set; }

    }
}