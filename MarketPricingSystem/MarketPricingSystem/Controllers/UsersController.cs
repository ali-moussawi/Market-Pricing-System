using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.Models;
using Org.BouncyCastle.Asn1.X509;

namespace MarketPricingSystem.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {

        private marketpricingContext _context;

        public UsersController()
        {
            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Settings()
        {
            var gmail = User.Identity.Name;
            Users user = _context.Users.FirstOrDefault(u => u.Gmail == gmail);


            return View(user);
        }

        public ActionResult Updatesettings( string gmail , string name, string phone, string newpassword)
        {
            var targetuser = _context.Users.FirstOrDefault(u => u.Gmail == gmail);

            if (!String.IsNullOrEmpty(name))
            {
                targetuser.Name = name;
                _context.SaveChanges();

            }
            if (!String.IsNullOrEmpty(phone))
            {
                targetuser.PhoneNumber = phone;
                _context.SaveChanges();

            }
            if (!String.IsNullOrEmpty(newpassword))
            {
                targetuser.Password = newpassword;
                _context.SaveChanges();

            }



            return RedirectToAction("Dashboard");
        }

    }
}