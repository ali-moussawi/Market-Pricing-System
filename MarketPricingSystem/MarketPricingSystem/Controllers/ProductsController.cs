﻿using MarketPricingSystem.Models;
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
        private productDal productDal = new productDal();

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
           
            List < product > pdlist= productDal.ProductList();
          

            return View(pdlist);

        }



        public ActionResult Deleteproduct(int id)
        {
            
            var targetproduct = productDal.product(id) ;

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
            var targetproduct = _context.Products.FirstOrDefault(m => m.ProductId == id);
            var allcategories = _context.Categories.ToList();

            productandcategory productandcategory = new productandcategory
            {
                Product = targetproduct,
                Categories = allcategories,
            };
            
           
          


            return View(productandcategory);
        }




        [HttpPost]
        public ActionResult Confirmupdate(int Productid, string productname, int Barcode, string ProductDescription, int Categoryid)
        {
            var targetproduct = _context.Products.FirstOrDefault(p => p.ProductId == Productid);

            targetproduct.ProductDescription = ProductDescription;
            targetproduct.ProductName = productname;
            targetproduct.BarcodeNb = Barcode;
            targetproduct.CategoryId = Categoryid;

            _context.SaveChanges();
            List<product> pdlist = productDal.ProductList();

            return View("AllProducts", pdlist);
        }



        public ActionResult Createproduct()
        {
            var allcategories = _context.Categories.ToList();


            return View(allcategories);
        }


        [HttpPost]
        public ActionResult ConfirmCreate(string productname, int Barcode, string ProductDescription, int Categoryid)
        {
            Products product = new Products();

            product.ProductName = productname;
            product.BarcodeNb = Barcode;
            product.ProductDescription = ProductDescription;
            product.CategoryId = Categoryid;
            _context.Products.Add(product);
            _context.SaveChanges();

            List<product> pdlist = productDal.ProductList();



            return View("AllProducts", pdlist);
        }

    }
}