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

        private otherDal otherdal = new otherDal();

        

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

            var userslist = _context.Users.Where(u => u.Gmail != "aha057@usal.edu.lb").ToList();

            return View(userslist);

        }


        public ActionResult Userroles(int id )
        {
            List<MarketPricingSystem.Models.Roles> roles = otherdal.userroles(id);

            return View(roles);

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