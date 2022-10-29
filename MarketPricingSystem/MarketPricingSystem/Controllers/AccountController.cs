using MarketPricingSystem.Models;
using MarketPricingSystem.security;
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
         
        private EncryptandDecrypt encryptandDecrypt = new EncryptandDecrypt();
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


        [HttpGet]
        public ActionResult Unauthorized()
        {
            return View();
        }





        [HttpPost]
        public ActionResult Validatesignin(string Gmail, string Password)
        {
            Password = encryptandDecrypt.EncryptPassword(Password);

            var userindb = _context.Users.Where(x => x.Gmail == Gmail && x.Password == Password).FirstOrDefault();

            if (userindb != null)
            {
                var userid = userindb.UserId;
         
                var roleid = _context.Users.Where(x => x.UserId == userid).FirstOrDefault().Roleid;

                var rolename = _context.Roles.Where(x => x.RoleId == roleid).FirstOrDefault().RoleName.ToLower();

                FormsAuthentication.SetAuthCookie(userindb.Gmail.ToString() + "," + rolename.ToString(), false);


                //add user permissions to cookie

                var permissionsid = _context.Rolepermissions.Where(pr => pr.RoleId == roleid).ToList();

                List<string> permissions = new List<string>();

                foreach(var pid in permissionsid)
                {
                    permissions.Add(_context.Permissions.FirstOrDefault(p=>p.PermissionId == pid.PermissionId).PermissionName);

                }


                string allpermissions="";

                foreach(var perm in permissions)
                {

                    allpermissions += perm + ",";
                }

                HttpCookie sameSiteCookie = new HttpCookie("Permissions");



                sameSiteCookie.Value = encryptandDecrypt.EncryptPassword(allpermissions);
                sameSiteCookie.Secure = true;
                //add cookie to cookie collection
                Response.Cookies.Add(sameSiteCookie);


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