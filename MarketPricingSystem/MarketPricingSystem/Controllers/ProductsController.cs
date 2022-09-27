using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.DAL;
using MarketPricingSystem.ViewModel;
using MarketPricingSystem.CustomAuthorization;
using System.Web.Security;

namespace MarketPricingSystem.Controllers
{
    [Authorize]
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



        [PermissionAuthorization(Roles = "viewproduct")]
        public ActionResult AllProducts()
        {
           
            List < product > pdlist= productDal.ProductList();
          

            return View(pdlist);

        }




        [PermissionAuthorization(Roles = "deleteproduct")]
        public ActionResult ConfirmDelete(int id)
        {
            var targetproduct = _context.Products.FirstOrDefault(m => m.ProductId == id);

            _context.Products.Remove(targetproduct);
            _context.SaveChanges();

            return RedirectToAction("AllProducts");
        }



        [PermissionAuthorization(Roles = "updateproduct")]
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



        [PermissionAuthorization(Roles = "updateproduct")]
        [HttpPost]
        public ActionResult Confirmupdate(int Productid, string productname, int Barcode, string ProductDescription, int? Categoryid)
        {
            var targetproduct = _context.Products.FirstOrDefault(p => p.ProductId == Productid);


            if (targetproduct.ProductName != productname)
            {
                var checkdbproductname = _context.Products.FirstOrDefault(p => p.ProductName == productname);

                if (checkdbproductname != null)
                {
                    TempData["Message1"] = "Product name already taken";

                    return RedirectToAction("Updateproduct", new { @id = targetproduct.ProductId });
                }
            }

            if (targetproduct.BarcodeNb != Barcode)
            {
                var checkdbproductbr = _context.Products.FirstOrDefault(p => p.BarcodeNb == Barcode);

                if (checkdbproductbr != null)
                {
                    TempData["Message2"] = "Barcode Already Exists";

                    return RedirectToAction("Updateproduct", new { @id = targetproduct.ProductId });

                }
            }
            if (Categoryid == null)
            {

                TempData["Message3"] = "Please select a category";

                return RedirectToAction("Updateproduct", new { @id = targetproduct.ProductId });

            }

            targetproduct.ProductName = productname;
            targetproduct.BarcodeNb=Barcode;
            targetproduct.ProductDescription = ProductDescription;
            targetproduct.CategoryId = Categoryid.Value;
            _context.SaveChanges();


            return RedirectToAction("AllProducts");
        }



        [PermissionAuthorization(Roles = "addproduct")]
        public ActionResult Createproduct()
        {
            var allcategories = _context.Categories.Where(c => c.CategoryName != "NO CATEGORY").ToList();


            return View(allcategories);
        }


        [PermissionAuthorization(Roles = "addproduct")]
        [HttpPost]
        public ActionResult ConfirmCreate(string productname, int Barcode, string ProductDescription, int? Categoryid)
        {
         


            var checkdbproductname = _context.Products.FirstOrDefault(p => p.ProductName == productname);
            if (checkdbproductname != null)
            {
                TempData["Message1"] = "Product name already taken";
                var allcategories = _context.Categories.Where(c => c.CategoryName != "NO CATEGORY").ToList();
                return RedirectToAction("Createproduct", allcategories);
            }



            var checkdbproductbr = _context.Products.FirstOrDefault(p => p.BarcodeNb == Barcode);

            if (checkdbproductbr != null)
            {
                var allcategories = _context.Categories.Where(c => c.CategoryName != "NO CATEGORY").ToList();

                TempData["Message2"] = "Barcode Already Exists";

                return RedirectToAction("Createproduct", allcategories);
            }

            if (Categoryid == null)
            {

                TempData["Message3"] = "Please select a category";

                return RedirectToAction("Createproduct");

            }

                Products product = new Products();

                product.ProductName = productname;
                product.BarcodeNb = Barcode;
                product.ProductDescription = ProductDescription;
                product.CategoryId = Categoryid.Value;
                _context.Products.Add(product);
                _context.SaveChanges();

                List<product> pdlist = productDal.ProductList();



                return RedirectToAction("AllProducts", pdlist);
            

         
        }

    }
}