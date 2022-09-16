using MarketPricingSystem.Models;
using MarketPricingSystem.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MarketPricingSystem.DAL
{
    public class CategoryDAL
    {

        public void setproductnocategory(int Categoryid)
        {
            int nocategoryid=0;
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing"))
            {
                string query = "select categoryid from categories where categoryname = 'no category' ";

                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            nocategoryid = Convert.ToInt32(sdr["categoryid"]);
                           
                        }
                    }
                    con.Close();
                }
                string query2 = " update products  set categoryid=" + nocategoryid + "  where categoryid=" +Categoryid;
                using (MySqlCommand cmd = new MySqlCommand(query2))
                {
                    cmd.Connection = con;
                    con.Open();
                    MySqlDataReader sdr = cmd.ExecuteReader();

                }
                con.Close();
            }




        }
    }
}