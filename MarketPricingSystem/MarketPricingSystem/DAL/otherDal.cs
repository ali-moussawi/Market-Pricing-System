using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MarketPricingSystem.Models;
using MySql.Data.MySqlClient;
using MarketPricingSystem.ViewModel;
using System.Data;

namespace MarketPricingSystem.DAL
{
    public class otherDal
    {

        private marketpricingContext _context = new marketpricingContext();


        private readonly MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing");







        public List<Userdetails> allusers()
        {
            List<Userdetails> users= new List<Userdetails>();




            using (MySqlCommand cmd = new MySqlCommand("Allusers", con))
            {
                cmd.Connection = con;
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        users.Add(new Userdetails
                        {
                            userid = Convert.ToInt32(sdr["userid"]),
                            username = sdr["name"].ToString(),
                            userphonenumber = sdr["phonenumber"].ToString(),
                            usergmail = sdr["gmail"].ToString(),
                            userpassword = sdr["password"].ToString(),
                            rolename = sdr["rolename"].ToString(),

                        });
                    }
                }
                con.Close();
            }
            return users;
        }



    }




















}
