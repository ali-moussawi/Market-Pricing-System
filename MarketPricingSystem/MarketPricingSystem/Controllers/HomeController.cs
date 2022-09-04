using MarketPricingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPricingSystem.Controllers
{
    public class HomeController : Controller
    {
       private marketpricingContext _context;

        public HomeController()
        {
            _context = new marketpricingContext();  
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult validatesignin()
        {
            return View();
        }

        public ActionResult SuperMarketList()
        {
            var supermarketlist = _context.Supermarket.Include(m => m.Usersphonenumber).ToList();

            return View(supermarketlist);


        }

        public ActionResult Options()
        {

            return View();
        }


        public ActionResult ProductList(int id)
        {
           // var allproducts = _context.Supermarketproducts.Where(s => s.SuperMarketId == id).Include(x => x.Productprices).ToList();
            return View();

        }
    }
}