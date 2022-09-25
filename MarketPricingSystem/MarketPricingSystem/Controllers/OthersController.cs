using MarketPricingSystem.DAL;
using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.ViewModel;
using MarketPricingSystem.security;
using MarketPricingSystem.CustomAuthorization;
using System.Web.Security;

namespace MarketPricingSystem.Controllers
{
    [Authorize]
    public class OthersController : Controller
    {
        private EncryptandDecrypt encryptandDecrypt = new EncryptandDecrypt();
        private otherDal _otherdal = new otherDal();

        

        private marketpricingContext _context;

        public OthersController()
        {

            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [PermissionAuthorization(Roles = "viewusers")]
        public ActionResult Allusers()
        {

            List<Userdetails> users = _otherdal.allusers();




            return View(users);

        }



        [PermissionAuthorization(Roles = "updateuser")]
        public ActionResult Updateuser(int id)
        {
           Userandroles updateuser = new Userandroles();
            var targetuser = _context.Users.FirstOrDefault(u => u.UserId == id);
            targetuser.Password =encryptandDecrypt.DecryptPassword(targetuser.Password);
            var rolelist = _context.Roles.Where(r=> r.RoleName != "Admin").ToList();
            updateuser.User=targetuser;
            updateuser.Rolelist=rolelist;



            return View(updateuser);
        }


        [PermissionAuthorization(Roles = "updateuser")]
        public ActionResult Confirmupdate(int userid, string username, string phonenumber , string password, int roleid)
        {
            var targetuser = _context.Users.FirstOrDefault(m => m.UserId == userid);



           

            if (!String.IsNullOrWhiteSpace(password) && !String.IsNullOrEmpty(password))
            {
                password = encryptandDecrypt.EncryptPassword(password);

                targetuser.Password = password;
            }


            if (targetuser.PhoneNumber != phonenumber)
            {
                var checknb = _context.Users.FirstOrDefault(u => u.PhoneNumber == phonenumber);

                if (checknb != null)
                {
                    TempData["Message1"] = "Phone number Already in use";

                    return RedirectToAction("Updateuser", new { @id= targetuser.UserId});
                }
            }

            targetuser.Roleid = roleid;
            targetuser.Name = username;
            targetuser.PhoneNumber = phonenumber;
            _context.SaveChanges();

            return RedirectToAction("Allusers");
        }






        [PermissionAuthorization(Roles = "deleteuser")]
        public ActionResult ConfirmDelete(int id)
        {
            var targetuser = _context.Users.FirstOrDefault(m => m.UserId == id);

            _context.Users.Remove(targetuser);
            _context.SaveChanges();

            return RedirectToAction("Allusers");
        }



        [PermissionAuthorization(Roles = "adduser")]
        public ActionResult Createuser()
        {
            var roleslist = _context.Roles.Where(r=>r.RoleName != "Admin").ToList();
            

            return View(roleslist);
        }



        [PermissionAuthorization(Roles = "adduser")]
        public ActionResult Confirmcreate(string username ,string phonenumber, string gmail, string password,  int? roleid)
        {
           



            var chechnb = _context.Users.FirstOrDefault(u => u.PhoneNumber == phonenumber);
            if (chechnb != null)
            {
                TempData["Message1"] = "Phone number Already in use";
                return RedirectToAction("Createuser");
             


            }

            var chechgmail = _context.Users.FirstOrDefault(u => u.Gmail == gmail);
            if (chechgmail != null)
            {
                TempData["Message2"] = "Email Already in use";
                return RedirectToAction("Createuser");


            }
            if (roleid == null)
            {
                TempData["Message3"] = "Please select a role";
                return RedirectToAction("Createuser");
            }


            Users newuser = new Users();
            newuser.Name = username;
            newuser.PhoneNumber = phonenumber;
            newuser.Gmail = gmail;

            password = encryptandDecrypt.EncryptPassword(password);

            newuser.Password = password;
            newuser.Roleid = roleid.Value;
            _context.Users.Add(newuser);
            _context.SaveChanges();



            return RedirectToAction("Allusers");
        }







    }
}