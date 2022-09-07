using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MarketPricingSystem.Controllers
{
    public class AccountController : Controller
    {

        private marketpricingContext _context;

        public AccountController()
        {
            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }






        [HttpPost]
        public ActionResult Validatesignin(string gmail, string password)
        {
            gmail = gmail.ToLower();
            password = password.ToLower();
            var userindb = _context.Usergmails.Where(x => x.UserGmail == gmail && x.Password == password).FirstOrDefault();

            if (userindb != null)
            {
                var userid = userindb.UserId;
                var permissionid = _context.Userpermissions.Where(x => x.UserId == userid).FirstOrDefault().PermissionId;
                var permissionname = _context.Permissions.Where(x => x.PermissionId == permissionid).FirstOrDefault().PermissionName.ToLower();

                FormsAuthentication.SetAuthCookie(userindb.UserGmail, false);

                Session["permission"] = permissionname;

                var tst = Session["permission"];
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or password is wrong ");
            return View("signin");


        }


    }
}