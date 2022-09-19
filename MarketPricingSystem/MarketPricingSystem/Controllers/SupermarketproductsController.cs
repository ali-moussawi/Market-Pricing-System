using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.DAL;
using MarketPricingSystem.Models;
using MarketPricingSystem.ViewModel;

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


            marketandproducts.marketid = targetsupermarktetid;
            marketandproducts.allproducts = allproducts;


            return View(marketandproducts);
        }



        public ActionResult Confirmcreate(int marketid, int productid, int price)
        {
            var checksameprice = _context.Productprices.FirstOrDefault(p => p.Supermarketid == marketid && p.ProductId == productid && p.IsActivePrice == 0);
            if (checksameprice != null)
            {
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
            else {
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



    }
}