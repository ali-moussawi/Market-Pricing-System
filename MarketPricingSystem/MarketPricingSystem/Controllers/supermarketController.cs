using MarketPricingSystem.CustomAuthorization;
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




        [PermissionAuthorization(Roles = "viewsupermarket")]
        public ActionResult Allsupermarkets()
        {

            var supermarketlist = _context.Supermarket.ToList();

            return View(supermarketlist);

        }




        [PermissionAuthorization(Roles = "deletesupermarket")]
        public ActionResult ConfirmDelete(int id)
        {
            var targetsupermarket = _context.Supermarket.FirstOrDefault(m => m.SupermarketId == id);

            _context.Supermarket.Remove(targetsupermarket);
            _context.SaveChanges();

            return RedirectToAction("Allsupermarkets");
        }

        [PermissionAuthorization(Roles = "updatesupermarket")]
        public ActionResult Updatesupermarket(int id)
        {
            var targetsupermarket = _context.Supermarket.FirstOrDefault(m => m.SupermarketId == id);
            


            return View(targetsupermarket);
        }


        [PermissionAuthorization(Roles = "updatesupermarket")]
        [HttpPost]
        public ActionResult Confirmupdate(int Supermarketid, string MarketName, string MarketRegion, string MarketDescription, string MarketNumber)
        {
            var targetsupermarket = _context.Supermarket.FirstOrDefault(m => m.SupermarketId == Supermarketid);
            targetsupermarket.SupermarketDescription = MarketDescription;
            _context.SaveChanges();


            if (targetsupermarket.SupermarketName!=MarketName && targetsupermarket.SupermarketRegion!=MarketRegion) {
                var checkdbmarketname_region = _context.Supermarket.FirstOrDefault(p => p.SupermarketName == MarketName && p.SupermarketRegion == MarketRegion);


                if (checkdbmarketname_region != null)
                {
                    TempData["Message1"] = "Supermarket name and Region Already Exists";



                    return RedirectToAction("Updatesupermarket", new { @id = Supermarketid });

                }

            }

            if (targetsupermarket.Phonenumber != MarketNumber)
            {
                var numberdb = _context.Supermarket.FirstOrDefault(m => m.Phonenumber == MarketNumber);

                if (numberdb != null)
                {

                     TempData["Message2"] = "Phone number already taken";

                    return RedirectToAction("Updatesupermarket", new { @id = Supermarketid });
                }

            }

            targetsupermarket.SupermarketName = MarketName;
            targetsupermarket.SupermarketRegion = MarketRegion;
            targetsupermarket.SupermarketDescription = MarketDescription;
            targetsupermarket.Phonenumber = MarketNumber;
            _context.SaveChanges();



            var supermarketlist = _context.Supermarket.ToList();
            return RedirectToAction("Allsupermarkets",supermarketlist);
        }


        [PermissionAuthorization(Roles = "addsupermarket")]
        public ActionResult Createsupermarket()
        {

            return View();
        }



        [PermissionAuthorization(Roles = "addsupermarket")]
        [HttpPost]
        public ActionResult ConfirmCreate(string MarketName, string MarketRegion, string MarketDescription, string MarketNumber)
        {



            var checkdbmarketname_region = _context.Supermarket.FirstOrDefault(p => p.SupermarketName == MarketName && p.SupermarketRegion == MarketRegion);


            if (checkdbmarketname_region != null)
            {

                TempData["Message1"]  = "Supermarket name and Region Already Exists";


               
                return RedirectToAction("Createsupermarket");
                
            }

            var marketnumber = _context.Supermarket.FirstOrDefault(p => p.Phonenumber == MarketNumber);


            if (marketnumber != null)
            {
                TempData["Message2"] = "Phone number already taken";



                return RedirectToAction("Createsupermarket");
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