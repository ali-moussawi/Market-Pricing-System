using MarketPricingSystem.DAL;
using MarketPricingSystem.Models;
using MarketPricingSystem.ViewModel;
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

            var checkdbmarketname_region = _context.Supermarket.FirstOrDefault(p => p.SupermarketName == MarketName && p.SupermarketRegion == MarketRegion);


            if (checkdbmarketname_region != null)
            {
                targetsupermarket.SupermarketDescription = MarketDescription;
                _context.SaveChanges();

                if (targetsupermarket.Phonenumber != MarketNumber)
                {
                    var numberdb = _context.Supermarket.FirstOrDefault(m => m.Phonenumber == MarketNumber);
                    if (numberdb != null)
                    {

                        var supermarketlist3 = _context.Supermarket.ToList();
                        return RedirectToAction("Allsupermarkets", supermarketlist3);
                    }
             
                }
                
                targetsupermarket.Phonenumber = MarketNumber;

                _context.SaveChanges();

                var supermarketlist1 = _context.Supermarket.ToList();
                return RedirectToAction("Allsupermarkets", supermarketlist1);
            }



           
                targetsupermarket.SupermarketName = MarketName;
                targetsupermarket.SupermarketRegion = MarketRegion;

          
            targetsupermarket.SupermarketDescription = MarketDescription;
            _context.SaveChanges();



            if (targetsupermarket.Phonenumber != MarketNumber)
            {
                var numberdb = _context.Supermarket.FirstOrDefault(m => m.Phonenumber == MarketNumber);
                if (numberdb != null)
                {

                    var supermarketlist3 = _context.Supermarket.ToList();
                    return RedirectToAction("Allsupermarkets", supermarketlist3);
                }

            }

            targetsupermarket.Phonenumber = MarketNumber;
           
           
            _context.SaveChanges();

            var supermarketlist = _context.Supermarket.ToList();
            return RedirectToAction("Allsupermarkets",supermarketlist);
        }



        public ActionResult Createsupermarket()
        {

            return View();
        }


        [HttpPost]
        public ActionResult ConfirmCreate(string MarketName, string MarketRegion, string MarketDescription, string MarketNumber)
        {



            var checkdbmarketname_region = _context.Supermarket.FirstOrDefault(p => p.SupermarketName == MarketName && p.SupermarketRegion == MarketRegion);


            if (checkdbmarketname_region != null)
            {
                var supermarketlist1 = _context.Supermarket.ToList();
                return RedirectToAction("Allsupermarkets",supermarketlist1);
                
            }

            var marketnumber = _context.Supermarket.FirstOrDefault(p => p.Phonenumber == MarketNumber);


            if (marketnumber != null)
            {
                var supermarketlist2 = _context.Supermarket.ToList();
                return RedirectToAction("Allsupermarkets", supermarketlist2);
            }







            Supermarket market = new Supermarket();
        
            market.SupermarketName = MarketName;
            market.SupermarketRegion = MarketRegion;
            market.Phonenumber = MarketNumber;
            market.SupermarketDescription = MarketDescription;
            _context.Supermarket.Add(market);
            _context.SaveChanges();
            var supermarketlist = _context.Supermarket.ToList();
            return RedirectToAction("Allsupermarkets", supermarketlist);
        }


    }
}