using MarketPricingSystem.DAL;
using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPricingSystem.Controllers
{
    public class OthersController : Controller
    {

        private RolesDal roleDal = new RolesDal();

        private marketpricingContext _context;

        public OthersController()
        {

            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public ActionResult Allusers()
        {

            var rolelist = _context.Roles.ToList();

            return View(rolelist);

        }
















    }
}