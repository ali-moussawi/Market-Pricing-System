using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.Models;
using Org.BouncyCastle.Asn1.X509;
using MarketPricingSystem.security;
namespace MarketPricingSystem.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private EncryptandDecrypt encryptandDecrypt =new EncryptandDecrypt();
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
            List<int> data = new List<int>();
            int supermarket = _context.Supermarket.Count();
            int products = _context.Products.Count();
            int categories = _context.Categories.Where(c=>c.CategoryName !="NO CATEGORY").Count();
            int users = _context.Users.Where(u => u.Gmail !="admin@gmail.com").Count();

            data.Add(supermarket);
            data.Add(products);
            data.Add(categories);
            data.Add(users);




            return View(data);
        }

        public ActionResult Settings()
        {
            var gmail = User.Identity.Name.Split(',').First();
            Users user = _context.Users.FirstOrDefault(u => u.Gmail == gmail);
            user.Password = encryptandDecrypt.DecryptPassword(user.Password);
            return View(user);
        }

        public ActionResult Updatesettings( int userid, string name, string phone, string newpassword)
        {



            var targetuser = _context.Users.FirstOrDefault(u => u.UserId == userid);

           

            if(targetuser.PhoneNumber != phone)
            {

                var uphonenb = _context.Users.FirstOrDefault(u => u.PhoneNumber == phone);
                if (uphonenb != null)
                {
                    TempData["Message1"] = "Phone number already in use";

                    return RedirectToAction("Settings");
                }


            }
           





            if (!String.IsNullOrWhiteSpace(newpassword) && !String.IsNullOrEmpty(newpassword))
            {
                targetuser.Password = encryptandDecrypt.EncryptPassword(newpassword);
            }


            targetuser.Name = name;
            targetuser.PhoneNumber = phone;
            _context.SaveChanges();


            return RedirectToAction("Dashboard");
        }

    }
}