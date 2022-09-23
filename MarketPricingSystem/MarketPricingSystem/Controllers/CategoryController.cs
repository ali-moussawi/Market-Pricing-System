using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.DAL;
using MarketPricingSystem.CustomAuthorization;
using System.Web.Security;

namespace MarketPricingSystem.Controllers
{
    public class CategoryController : Controller
    {

        private CategoryDAL _categoryDAL = new CategoryDAL();

        private marketpricingContext _context;

        public CategoryController()
        {
            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [PermissionAuthorization(Roles = "viewcategory")]
        public ActionResult AllCategories() { 

            var categoryList = _context.Categories.Where(c=>c.CategoryName != "NO CATEGORY").ToList();

            return View(categoryList);

        }


        [PermissionAuthorization(Roles = "deletecategory")]
        public ActionResult ConfirmDelete(int id)
        {
            _categoryDAL.setproductnocategory(id);


            var targetcategory = _context.Categories.FirstOrDefault(m => m.CategoryId == id);

            _context.Categories.Remove(targetcategory);
            _context.SaveChanges();

            return RedirectToAction("AllCategories");
        }



        [PermissionAuthorization(Roles = "updatecategory")]
        public ActionResult Updatecategory(int id)
        {
            var targetcategory = _context.Categories.FirstOrDefault(m => m.CategoryId == id);



            return View(targetcategory);
        }


        [PermissionAuthorization(Roles = "updatecategory")]
        [HttpPost]
        public ActionResult Confirmupdate(int Categoryid, string Categoryname)
        {
            var targetcategory = _context.Categories.FirstOrDefault(m => m.CategoryId == Categoryid);


            if (targetcategory.CategoryName != Categoryname)
            {


                var checkdb = _context.Categories.FirstOrDefault(c => c.CategoryName == Categoryname);
                if (checkdb != null)
                {
                    TempData["Message1"] = "Category already exists";

                    return RedirectToAction("Updatecategory", new {@id = targetcategory.CategoryId });

                }

            }
          

           
                targetcategory.CategoryName = Categoryname;
                _context.SaveChanges();

                var categorylist = _context.Categories.ToList();
                return RedirectToAction("AllCategories", categorylist);    
        }




        [PermissionAuthorization(Roles = "addcategory")]
        public ActionResult Createcategory()
        {

            return View();
        }

        [PermissionAuthorization(Roles = "addcategory")]
        [HttpPost]
        public ActionResult ConfirmCreate(string CategoryName)
        {

            var checkdb =_context.Categories.FirstOrDefault(c => c.CategoryName == CategoryName);   
            if(checkdb != null)
            {
                TempData["Message1"] = "Category already exists";
                return RedirectToAction("Createcategory");
                    
            }



            Categories category = new Categories();
            category.CategoryName = CategoryName;

            _context.Categories.Add(category);
            _context.SaveChanges();
            var categorylist = _context.Categories.ToList();
            return RedirectToAction("AllCategories", categorylist);
        }












    }
}