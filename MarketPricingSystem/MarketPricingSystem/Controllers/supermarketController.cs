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

            var supermarketlist = _context.Supermarket.ToList();

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
            var targetsupermarket = _context.Supermarket.FirstOrDefault(m => m.SupermarketId == id);
            


            return View(targetsupermarket);
        }
        [HttpPost]
        public ActionResult Confirmupdate(int Supermarketid, string MarketName, string MarketRegion, string MarketDescription, string MarketNumber)
        {

            var targetsupermarket = _context.Supermarket.FirstOrDefault(m => m.SupermarketId == Supermarketid);
            if(!string.IsNullOrEmpty(MarketName))
            {
                targetsupermarket.SupermarketName = MarketName;
            }
            if(!string.IsNullOrEmpty(MarketRegion))
            {
                targetsupermarket.SupermarketRegion = MarketRegion;
            }
          
           if(!string.IsNullOrEmpty(MarketDescription))
            {
                targetsupermarket.SupermarketDescription = MarketDescription;
            }
            if(!string.IsNullOrEmpty(MarketNumber))
            {
                targetsupermarket.Phonenumber = MarketNumber;
            }
           
            _context.SaveChanges();

            var supermarketlist = _context.Supermarket.ToList();
            return View("Allsupermarkets",supermarketlist);
        }



        public ActionResult Createsupermarket()
        {

            return View();
        }


        [HttpPost]
        public ActionResult ConfirmCreate(string MarketName, string MarketRegion, string MarketDescription, string MarketNumber)
        {
            Supermarket market = new Supermarket();
        
            market.SupermarketName = MarketName;
            market.SupermarketRegion = MarketRegion;
            market.Phonenumber = MarketNumber;
            market.SupermarketDescription = MarketDescription;
            _context.Supermarket.Add(market);
            _context.SaveChanges();
            var supermarketlist = _context.Supermarket.ToList();
            return View("Allsupermarkets", supermarketlist);
        }


    }
}