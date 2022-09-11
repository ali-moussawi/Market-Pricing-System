using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.DAL;
using MarketPricingSystem.ViewModel;

namespace MarketPricingSystem.Controllers
{
    public class ProductsController : Controller
    {
        private marketpricingContext _context;
        private productDal product = new productDal();

        public ProductsController()
        {
            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public ActionResult AllProducts()
        {
           
            List < product > pdlist= product.ProductList();
          

            return View(pdlist);

        }



        public ActionResult Deleteproduct(int id)
        {
            
            var targetproduct = product.product(id) ;

            return View(targetproduct);
        }




        public ActionResult ConfirmDelete(int id)
        {
            var targetproduct = _context.Products.FirstOrDefault(m => m.ProductId == id);

            _context.Products.Remove(targetproduct);
            _context.SaveChanges();

            return RedirectToAction("AllProducts");
        }




        public ActionResult Updateproduct(int id)
        {
            var targetsupermarket = _context.Products.FirstOrDefault(m => m.ProductId == id);



            return View(targetsupermarket);
        }
        [HttpPost]
        public ActionResult Confirmupdate(int Productid, string ProductName, int  Barcode, string ProductDescription, int Categoryid)
        {

         
          
            return View( );
        }



        public ActionResult Createproduct()
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