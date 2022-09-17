using MarketPricingSystem.DAL;
using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.ViewModel;

namespace MarketPricingSystem.Controllers
{
    public class OthersController : Controller
    {

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




        public ActionResult Allusers()
        {

            List<Userdetails> users = _otherdal.allusers();




            return View(users);

        }


     



        public ActionResult Deleteuser(int id)
        {
            var targetuser = _context.Users.FirstOrDefault(m => m.UserId == id);

            return View(targetuser);
        }




            public ActionResult Updateuser(int id)
        {
           Userandroles updateuser = new Userandroles();
            var targetuser = _context.Users.FirstOrDefault(u => u.UserId == id);
            var rolelist = _context.Roles.Where(r=> r.RoleName != "Admin").ToList();
            updateuser.User=targetuser;
            updateuser.Rolelist=rolelist;



            return View(updateuser);
        }



                public ActionResult Confirmupdate(int userid, string username, string phonenumber , string password, int roleid)
        {


            var targetuser = _context.Users.FirstOrDefault(m => m.UserId == userid);
            targetuser.Name = username;
            targetuser.Password = password;
            targetuser.Roleid = roleid;
            _context.SaveChanges();

            var checknb = _context.Users.FirstOrDefault(u => u.PhoneNumber == phonenumber);

            if (checknb != null)
            {
                return RedirectToAction("Allusers");
            }


            targetuser.PhoneNumber = phonenumber;
            _context.SaveChanges();

            return RedirectToAction("Allusers");
        }


















        public ActionResult ConfirmDelete(int id)
        {
            var targetuser = _context.Users.FirstOrDefault(m => m.UserId == id);

            _context.Users.Remove(targetuser);
            _context.SaveChanges();

            return RedirectToAction("Allusers");
        }




        public ActionResult Createuser()
        {
            var roleslist = _context.Roles.Where(r=>r.RoleName != "Admin").ToList();
            

            return View(roleslist);
        }

            public ActionResult Confirmcreate(string username ,string phonenumber, string gmail, string password,  int roleid)
        {
            var chechnb = _context.Users.FirstOrDefault(u => u.PhoneNumber == phonenumber);
            if (chechnb != null)
            {
                return RedirectToAction("Allusers");


            }

            var chechgmail = _context.Users.FirstOrDefault(u => u.Gmail == gmail);
            if (chechgmail != null)
            {
                return RedirectToAction("Allusers");


            }

            Users newuser = new Users();
            newuser.Name = username;
            newuser.PhoneNumber = phonenumber;
            newuser.Gmail = gmail;
            newuser.Password = password;
            newuser.Roleid = roleid;
            _context.Users.Add(newuser);
            _context.SaveChanges();



            return RedirectToAction("Allusers");
        }







    }
}