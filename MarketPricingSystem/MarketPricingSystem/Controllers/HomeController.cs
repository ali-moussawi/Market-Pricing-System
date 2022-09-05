using MarketPricingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MySql.Data.MySqlClient;
using MarketPricingSystem.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

            List<productdetails> products = new List<productdetails>();
       
       //install sql connector to can open connection
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = "Select productname, BarcodeNb, productDescription, price from products p , productprices pc where pc.supermarketid = "+id.ToString()+ "  and p.productid = pc.productid and pc.IsActivePrice=0";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            products.Add(new productdetails
                            {
                                productname = sdr["productname"].ToString(),
                                productBarcode = Convert.ToInt32(sdr["BarcodeNb"]),
                                productDescription = sdr["productDescription"].ToString(),
                                productprice = Convert.ToInt32(sdr["price"]),
                                //category for each product
                            });
                        }
                    }
                    con.Close();
                }
            }

            return View(products);

            

        }

        public ActionResult Allproducts()
        {
            List<AllProducts> products = new List<AllProducts>();

            //install sql connector to can open connection
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = "select productid, productname, barcodenb, productdescription from products p where p.productid in (select distinct productid from productprices);";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            products.Add(new AllProducts
                            {
                                productid = Convert.ToInt32(sdr["productid"]),
                                productname = sdr["productname"].ToString(),
                                productBarcode = Convert.ToInt32(sdr["barcodenb"]),
                                productDescription= sdr["productdescription"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return View(products);

        }

        public ActionResult GetCheapestproduct(int id)
        {

            productvalue cheapproduct=new productvalue();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = " select supermarketname , productname , price  from supermarket s, products p , productprices pc where s.supermarketid = pc.supermarketid and p.productid = pc.productid and p.productid ="+id.ToString()+ " and pc.ISactiveprice=0    ORDER BY price ASC   limit 1 ;";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                             cheapproduct = new productvalue
                            {
                                supermarketname = sdr["supermarketname"].ToString(),
                                productname = sdr["productname"].ToString(),
                                productprice = Convert.ToInt32(sdr["price"]),

                            };
                          
                        }
                    }
                    con.Close();
                }

            }
            return View(cheapproduct);

        }


        public ActionResult GetExpensiveproduct(int id)
        {

            productvalue cheapproduct = new productvalue();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = " select supermarketname , productname , price  from supermarket s, products p , productprices pc where s.supermarketid = pc.supermarketid and p.productid = pc.productid and p.productid =" + id.ToString() + " and pc.ISactiveprice=0    ORDER BY price DESC   limit 1 ;";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            cheapproduct = new productvalue
                            {
                                supermarketname = sdr["supermarketname"].ToString(),
                                productname = sdr["productname"].ToString(),
                                productprice = Convert.ToInt32(sdr["price"]),

                            };

                        }
                    }
                    con.Close();
                }

            }
            return View(cheapproduct);

        }


    }


}