using MarketPricingSystem.Models;
using MarketPricingSystem.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MarketPricingSystem.DAL
{
    public class RolesDal
    {
        private marketpricingContext _context = new marketpricingContext();


        private readonly MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=123;database=marketpricing");





        public List<Permissions> Rolepermission (int roleid)
        {
            List<Permissions> permissions = new List<Permissions>();
            string query = "  select permissionname from permissions p , rolepermissions pr  where pr.roleid = "+roleid.ToString() + " and p.permissionid = pr.permissionid ";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        permissions.Add(new Permissions
                        {
                            PermissionName = sdr["permissionname"].ToString(),
                         
                        });
                    }
                }
                con.Close();
            }
            return permissions;
        }



        public  void addperTorole(int roleid , int perid)
        {
            Rolepermissions newrolepermission = new Rolepermissions();

            newrolepermission.RoleId = roleid;
            newrolepermission.PermissionId = perid;

                _context.Rolepermissions.Add(newrolepermission);
                _context.SaveChanges();
            


        }




     


    }
}