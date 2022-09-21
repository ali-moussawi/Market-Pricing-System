using MarketPricingSystem.Models;
using MarketPricingSystem.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
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
              

                using (MySqlCommand cmd = new MySqlCommand("Nocategoryid", con))
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
               
                using (MySqlCommand cmd = new MySqlCommand("updatecategorystatus", con))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nocategoryid", nocategoryid);
                    cmd.Parameters.AddWithValue("@categoryid", Categoryid);
                    MySqlDataReader sdr = cmd.ExecuteReader();

                }
                con.Close();
            }




        }
    }
}