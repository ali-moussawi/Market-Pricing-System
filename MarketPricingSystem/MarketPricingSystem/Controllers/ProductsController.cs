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
            var allcategories = _context.Categories.Where(c => c.CategoryName != "NO CATEGORY").ToList();

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
            targetproduct.CategoryId = Categoryid;
            _context.SaveChanges();



            var checkdbproductname = _context.Products.FirstOrDefault(p => p.ProductName == productname);

            if (checkdbproductname != null)
            {
             
                var checkdbproductbr1 = _context.Products.FirstOrDefault(p => p.BarcodeNb == Barcode);

                if (checkdbproductbr1 == null)
                {
                    targetproduct.BarcodeNb = Barcode;
                    _context.SaveChanges();
                  
                }


               
                List<product> pdlist3 = productDal.ProductList();

                return RedirectToAction("AllProducts", pdlist3);
            }

            targetproduct.ProductName = productname;
            _context.SaveChanges();





            var checkdbproductbr = _context.Products.FirstOrDefault(p => p.BarcodeNb == Barcode);

            if (checkdbproductbr != null)
            {
                List<product> pdlist1 = productDal.ProductList();

                return RedirectToAction("AllProducts", pdlist1);
            }
           
            targetproduct.BarcodeNb = Barcode;
            _context.SaveChanges();

            List<product> pdlist = productDal.ProductList();

            return RedirectToAction("AllProducts", pdlist);
        }



        public ActionResult Createproduct()
        {
            var allcategories = _context.Categories.Where(c => c.CategoryName != "NO CATEGORY").ToList();


            return View(allcategories);
        }


        [HttpPost]
        public ActionResult ConfirmCreate(string productname, int Barcode, string ProductDescription, int Categoryid)
        {

            var checkdbproductbr = _context.Products.FirstOrDefault(p => p.BarcodeNb == Barcode);
            if (checkdbproductbr != null)
            {
                List<product> pdlist2 = productDal.ProductList();



                return RedirectToAction("AllProducts",pdlist2);
                   
            }


            var checkdbproductname = _context.Products.FirstOrDefault(p => p.ProductName == productname);
            if (checkdbproductname != null)
            {
                List<product> pdlist3 = productDal.ProductList();



                return RedirectToAction("AllProducts",pdlist3);
            }
            else
            {

                Products product = new Products();

                product.ProductName = productname;
                product.BarcodeNb = Barcode;
                product.ProductDescription = ProductDescription;
                product.CategoryId = Categoryid;
                _context.Products.Add(product);
                _context.SaveChanges();

                List<product> pdlist = productDal.ProductList();



                return RedirectToAction("AllProducts", pdlist);
            }

         
        }

    }
}