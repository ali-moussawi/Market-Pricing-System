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




        public ActionResult ConfirmDelete(int id)
        {
            var targetuser = _context.Users.FirstOrDefault(m => m.UserId == id);

            _context.Users.Remove(targetuser);
            _context.SaveChanges();

            return RedirectToAction("Allusers");
        }




    




    }
}