using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketPricingSystem.ViewModel;
using MarketPricingSystem.Models;
using System.Web.Mvc;
using System.Data;

namespace MarketPricingSystem.DAL
{
    public class productDal
    {
       private readonly MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing");





        public List<productdetails> supermarketproductlist(int supermarketid)
        {
            List<productdetails> products = new List<productdetails>();




            using (MySqlCommand cmd = new MySqlCommand("Marketproducts", con))
            {
                cmd.Connection = con;
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@marketid", supermarketid);
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
           
                using (MySqlCommand cmd = new MySqlCommand("product", con))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", id);
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



        public List<product> ProductList()//need productid for future work //all products with categories without price
        {
            List<product> products = new List<product>();

            //install sql connector to can open connection
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
            
               using (MySqlCommand cmd = new MySqlCommand("ProductList", con))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
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








        public List<product> Allproducts()//need productid for future work//only all priced products (dont return products that are not priced)
        {
            List<product> products = new List<product>();

            //install sql connector to can open connection
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                using (MySqlCommand cmd = new MySqlCommand("Allproducts_withid", con))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
            
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

                using (MySqlCommand cmd = new MySqlCommand("Get_Cheapestproduct", con))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", id);

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
                using (MySqlCommand cmd = new MySqlCommand(" Get_Expensiveproduct", con))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", id);

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
