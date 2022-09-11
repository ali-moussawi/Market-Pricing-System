using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPricingSystem.Controllers
{
    public class PermissionController : Controller
    {
        private marketpricingContext _context;

        public PermissionController()
        {
            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public ActionResult Allpermissions()
        {

            var permissionlits = _context.Permissions.ToList();

            return View(permissionlits);

        }
    }
}