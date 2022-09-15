using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPricingSystem.Controllers
{
    public class CategoryController : Controller
    {



        private marketpricingContext _context;

        public CategoryController()
        {
            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public ActionResult AllCategories() { 

            var categoryList = _context.Categories.ToList();

            return View(categoryList);

        }



        public ActionResult Deletecategory(int id)
        {
            var targetcategory = _context.Categories.FirstOrDefault(m => m.CategoryId == id);

            return View(targetcategory);
        }




        public ActionResult ConfirmDelete(int id)
        {
            var targetcategory = _context.Categories.FirstOrDefault(m => m.CategoryId == id);

            _context.Categories.Remove(targetcategory);
            _context.SaveChanges();

            return RedirectToAction("AllCategories");
        }


        public ActionResult Updatecategory(int id)
        {
            var targetcategory = _context.Categories.FirstOrDefault(m => m.CategoryId == id);



            return View(targetcategory);
        }
        [HttpPost]
        public ActionResult Confirmupdate(int Categoryid, string Categoryname)
        {

            var targetcategory = _context.Categories.FirstOrDefault(m => m.CategoryId == Categoryid);

            if (!string.IsNullOrEmpty(Categoryname))
            {
                targetcategory.CategoryName = Categoryname;
                _context.SaveChanges();

                var categorylist = _context.Categories.ToList();
                return RedirectToAction("AllCategories", categorylist);
            }

            else
            {

                var categorylist = _context.Categories.ToList();
                return RedirectToAction("AllCategories", categorylist);
            }
        }



        public ActionResult Createcategory()
        {

            return View();
        }


        [HttpPost]
        public ActionResult ConfirmCreate(string CategoryName)
        {

            var checkdb =_context.Categories.FirstOrDefault(c => c.CategoryName == CategoryName);   
            if(checkdb != null)
            {
                var categories = _context.Categories.ToList();
                return RedirectToAction("AllCategories", categories);
                    
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