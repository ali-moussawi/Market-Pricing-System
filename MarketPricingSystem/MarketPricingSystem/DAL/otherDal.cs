using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MarketPricingSystem.Models;
using MySql.Data.MySqlClient;

namespace MarketPricingSystem.DAL
{
    public class otherDal
    {

        private marketpricingContext _context = new marketpricingContext();


        private readonly MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing");




        public List<MarketPricingSystem.Models.Roles> userroles(int userid)
        {



            List<MarketPricingSystem.Models.Roles> roles = new List<MarketPricingSystem.Models.Roles>();
            string query = "  select rolename from roles r, userroles ur where ur.userid ="+ userid.ToString()  +" and r.roleid = ur.roleid ";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        roles.Add(new MarketPricingSystem.Models.Roles
                        {
                             RoleName = sdr["rolename"].ToString(),

                        });
                    }
                }
                con.Close();
            }
            return roles;
        }




















    }
}