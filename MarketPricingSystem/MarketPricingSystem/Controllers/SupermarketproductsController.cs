using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.DAL;
using MarketPricingSystem.Models;
using MarketPricingSystem.ViewModel;
using Microsoft.EntityFrameworkCore.Internal;

namespace MarketPricingSystem.Controllers
{
    public class SupermarketproductsController : Controller
    {
        private marketpricingContext _context;

        public SupermarketproductsController()
        {
            _context = new marketpricingContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Allsupermarkets()
        {
            var allsupermarkets = _context.Supermarket.ToList();
            return View(allsupermarkets);
        }



        public ActionResult Supermarketproducts(int id)
        {
            productDal product = new productDal();
            List<productdetails> supermarketproducts = product.supermarketproductlist(id);



            marketidwithproducts marketidwithproducts = new marketidwithproducts();
            marketidwithproducts.marketid = id;
            marketidwithproducts.supermarketproducts = supermarketproducts;

            return View(marketidwithproducts);

        }

        public ActionResult Createproduct(int id)
        {
            marketandproducts marketandproducts = new marketandproducts();

            var targetsupermarktetid = _context.Supermarket.FirstOrDefault(m => m.SupermarketId == id).SupermarketId;

            var allproducts = _context.Products.ToList();

            var oldproductsadded = _context.Productprices.Where(p => p.Supermarketid == id && p.IsActivePrice == 0).ToList();

            List<int> productidtodelete = new List<int>();

            for (int i = 0; i < allproducts.Count(); i++)
            {
                for (int j = 0; j < oldproductsadded.Count(); j++)
                {
                    if (allproducts[i].ProductId == oldproductsadded[j].ProductId)
                    {
                        productidtodelete.Add(allproducts[i].ProductId);

                    }

                }

            }

            for (int i = 0; i < productidtodelete.Count(); i++)
            {

                for (int j = 0; j < allproducts.Count(); j++)
                {
                    if (allproducts[j].ProductId == productidtodelete[i])
                    {
                        allproducts.RemoveAt(j);
                    }
                }


            }
            marketandproducts.marketid = targetsupermarktetid;
            marketandproducts.allproducts = allproducts;


            return View(marketandproducts);

        }



        public ActionResult Confirmcreate(int marketid, int productid, int price)
        {
         
            
                Productprices newproductprice = new Productprices();
                newproductprice.ProductId = productid;
                newproductprice.Supermarketid = marketid;
                newproductprice.Price = price;
                newproductprice.Date = DateTime.Now;
                newproductprice.IsActivePrice = 0;
                _context.Productprices.Add(newproductprice);
                _context.SaveChanges();

                return RedirectToAction("Supermarketproducts", "Supermarketproducts", new { @id = marketid });


            }


        


        public ActionResult Updateproductprice(int marketid, int productid)
        {
            var targetproduct = _context.Productprices.FirstOrDefault(p => p.Supermarketid == marketid && p.ProductId == productid && p.IsActivePrice == 0);

            return View(targetproduct);
        }






        public ActionResult Confirmupdate(int marketid, int productid, int price)
        {

            var checksameprice = _context.Productprices.FirstOrDefault(p => p.Supermarketid == marketid && p.ProductId == productid && p.IsActivePrice == 0);

            if (checksameprice.Price == price)
            {

                return RedirectToAction("Supermarketproducts", "Supermarketproducts", new { @id = marketid });

            }
            else
            {
                checksameprice.IsActivePrice = 1;
                _context.SaveChanges();

                Productprices newproductprice = new Productprices();
                newproductprice.ProductId = productid;
                newproductprice.Supermarketid = marketid;
                newproductprice.Price = price;
                newproductprice.Date = DateTime.Now;
                newproductprice.IsActivePrice = 0;
                _context.Productprices.Add(newproductprice);
                _context.SaveChanges();

                return RedirectToAction("Supermarketproducts", "Supermarketproducts", new { @id = marketid });


            }
        }

        public ActionResult ConfirmDelete(int marketid, int productid)
        {
            var targetpricedproduct = _context.Productprices.FirstOrDefault(p => p.Supermarketid == marketid && p.ProductId == productid && p.IsActivePrice == 0);

            targetpricedproduct.IsActivePrice = 1;
            _context.SaveChanges();

            return RedirectToAction("Supermarketproducts", "Supermarketproducts", new { @id = marketid });


        }


    }
}