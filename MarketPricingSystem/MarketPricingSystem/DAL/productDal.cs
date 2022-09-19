using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketPricingSystem.ViewModel;
using MarketPricingSystem.Models;
using System.Web.Mvc;

namespace MarketPricingSystem.DAL
{
    public class productDal
    {
       private readonly MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing");





        public List<productdetails> supermarketproductlist(int supermarketid)
        {
            List<productdetails> products = new List<productdetails>();


            string query = " select p.productid, productname ,barcodenb,productdescription , price,categoryname from products p , categories c , productprices pc where p.productid = pc.productid and pc.supermarketid =" + supermarketid.ToString() + " and c.categoryid = p.categoryid and isactiveprice=0";

            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        products.Add(new productdetails
                        {   productid = Convert.ToInt32(sdr["productid"]),
                            productname = sdr["productname"].ToString(),
                            productBarcode = Convert.ToInt32(sdr["BarcodeNb"]),
                            productDescription = sdr["productDescription"].ToString(),
                            productprice = Convert.ToInt32(sdr["price"]),
                            productcategory = sdr["categoryname"].ToString(),

                        });
                    }
                }
                con.Close();
            }
            return products;
        }



        public product product(int id)//need productid for future work
        {
            product product = new product();

            //install sql connector to can open connection
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = "select productid, productname ,barcodenb , productdescription , categoryname from products p , categories c where p.categoryid = c.categoryid and p.productid = "+id.ToString();
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {

                        while (sdr.Read())
                        {


                            product.productid = Convert.ToInt32(sdr["productid"]);
                            product.productname = sdr["productname"].ToString();
                            product.productBarcode = Convert.ToInt32(sdr["barcodenb"]);
                            product.productDescription = sdr["productdescription"].ToString();
                            product.productcategory = sdr["categoryname"].ToString();
                           
                        }
                    }
                    con.Close();
                }
                return product;
            }

        }



        public List<product> ProductList()//need productid for future work
        {
            List<product> products = new List<product>();

            //install sql connector to can open connection
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = "select productid, productname ,barcodenb , productdescription , categoryname from products p , categories c where p.categoryid = c.categoryid";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            products.Add(new product
                            {
                                productid = Convert.ToInt32(sdr["productid"]),
                                productname = sdr["productname"].ToString(),
                                productBarcode = Convert.ToInt32(sdr["barcodenb"]),
                                productDescription = sdr["productdescription"].ToString(),
                                productcategory = sdr["categoryname"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
                return products;
            }

        }








        public List<product> Allproducts()//need productid for future work
        {
            List<product> products = new List<product>();

            //install sql connector to can open connection
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = "select productid, productname ,barcodenb , productdescription , categoryname from products p , categories c where p.categoryid = c.categoryid and p.productid in (select Distinct productid from productprices);";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            products.Add(new product
                            {
                                productid = Convert.ToInt32(sdr["productid"]),
                                productname = sdr["productname"].ToString(),
                                productBarcode = Convert.ToInt32(sdr["barcodenb"]),
                                productDescription = sdr["productdescription"].ToString(),
                                productcategory = sdr["categoryname"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
                return products;
            }

        }




        public List<productvalue> GetCheapestproduct(int id)
        {

            List<productvalue> topcheapthree = new List<productvalue>();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = " select supermarketname , productname , price  from supermarket s, products p , productprices pc where s.supermarketid = pc.supermarketid and p.productid = pc.productid and p.productid =" + id.ToString() + " and pc.ISactiveprice=0    ORDER BY price ASC   limit 3 ;";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            topcheapthree.Add(new productvalue
                            {
                                supermarketname = sdr["supermarketname"].ToString(),
                                productname = sdr["productname"].ToString(),
                                productprice = Convert.ToInt32(sdr["price"]),

                            });

                        }
                    }
                    con.Close();
                }

            }
            return topcheapthree;

        }



        public List<productvalue> GetExpensiveproduct(int id)
        {

            List<productvalue> topexpensivethree = new List<productvalue>();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = " select supermarketname , productname , price  from supermarket s, products p , productprices pc where s.supermarketid = pc.supermarketid and p.productid = pc.productid and p.productid =" + id.ToString() + " and pc.ISactiveprice=0    ORDER BY price DESC   limit 3 ;";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            topexpensivethree.Add(new productvalue
                            {
                                supermarketname = sdr["supermarketname"].ToString(),
                                productname = sdr["productname"].ToString(),
                                productprice = Convert.ToInt32(sdr["price"]),

                            });

                        }
                    }
                    con.Close();
                }

            }
            return topexpensivethree;

        }
















    }







}
