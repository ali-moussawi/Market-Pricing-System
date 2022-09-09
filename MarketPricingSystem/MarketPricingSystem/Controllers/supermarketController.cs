using MarketPricingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPricingSystem.Controllers
{
    public class SupermarketController : Controller
    {

        private marketpricingContext _context;

        public SupermarketController()
        {
            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public ActionResult Allsupermarkets()
        {

            var supermarketlist = _context.Supermarket.Include(m => m.Usersphonenumber).ToList();

            return View(supermarketlist);

        }



        public ActionResult Deletesupermarket(int id )
        {
            var targetsupermarket = _context.Supermarket.FirstOrDefault(m => m.SupermarketId == id);

            return View(targetsupermarket);
        }



      
        public ActionResult ConfirmDelete(int id)
        {
            var targetsupermarket = _context.Supermarket.FirstOrDefault(m => m.SupermarketId == id);

            _context.Supermarket.Remove(targetsupermarket);
            _context.SaveChanges();

            return RedirectToAction("Allsupermarkets");
        }


        public ActionResult Updatesupermarket(int id)
        {


            return View();
        }

        public ActionResult Confirmupdate(int id)
        {


            return View();
        }



        public ActionResult Createsupermarket()
        {

            return View();
        }


        [HttpPost]
        public ActionResult ConfirmCreate()
        {

            return View();
        }


    }
}