using MarketPricingSystem.Models;
using MarketPricingSystem.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPricingSystem.DAL
{
    public class TrackDal
    {

        public string productprices(int marketid , int productid )
        {


            string data = "";
          



            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = "   select productname, price, DATE_FORMAT(date, '%Y-%m-%d') as date from products p , productprices pp where p.productid = pp.productid  and pp.productid = "+productid +" and pp.supermarketid = "+marketid +" and pp.id in (select MAX(id) from productprices Group by date)";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {

                            if (!data.StartsWith(sdr["productname"].ToString()))
                            {
                                string name = sdr["productname"].ToString();

                                data += name + ",";

                            }
                            data+= sdr["price"].ToString()+"," ;
                            data+= sdr["date"] +"," ;

                        }
                    }
                    con.Close();
                }
            }
      

            return data;
        }
    }









}
