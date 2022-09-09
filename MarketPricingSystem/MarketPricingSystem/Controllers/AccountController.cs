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
           
            var userindb = _context.Usergmails.Where(x => x.UserGmail == gmail && x.Password == password).FirstOrDefault();

            if (userindb != null)
            {
                var userid = userindb.UserId;
                var roleid = _context.Userroles.Where(x => x.UserId == userid).FirstOrDefault().RoleId;
                var rolename = _context.Roles.Where(x => x.RoleId == roleid).FirstOrDefault().RoleName.ToLower();

                FormsAuthentication.SetAuthCookie(userindb.UserGmail, false);

               

               
                return RedirectToAction("Dashboard", "Users");
            }

            ModelState.AddModelError("", "Username or password is wrong ");
            return View("signin");


        }


        public ActionResult Signout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

    }
}