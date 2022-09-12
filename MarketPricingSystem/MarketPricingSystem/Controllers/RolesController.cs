using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.DAL;
namespace MarketPricingSystem.Controllers
{
    public class RolesController : Controller
    {

        private RolesDal roleDal = new RolesDal();

        private marketpricingContext _context;

        public RolesController()
        {

            _context = new marketpricingContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public ActionResult AllRoles()
        {

            var rolelist = _context.Roles.ToList();

            return View(rolelist);

        }



        public ActionResult Deleterole(int id)
        {
            var targetrole= _context.Roles.FirstOrDefault(m => m.RoleId == id);

            return View(targetrole);
        }




        public ActionResult ConfirmDelete(int id)
        {
            var targetrole = _context.Roles.FirstOrDefault(m => m.RoleId == id);

            _context.Roles.Remove(targetrole);
            _context.SaveChanges();

            return RedirectToAction("AllRoles");
        }


        public ActionResult Rolepermissions(int id)
        {
            IEnumerable<Permissions> permissions = roleDal.Rolepermission(id);

            return View(permissions);
        }




        public ActionResult Createrole()
        {

            return View();
        }


        [HttpPost]
        public ActionResult ConfirmCreate(string Rolename, int? perone, int? pertwo, int? perthree, int? perfour, int? perfive, int? persix)
        {

            var checkdb = _context.Roles.FirstOrDefault(c => c.RoleName == Rolename);
            if (checkdb != null)
            {
                var rolelist = _context.Roles.ToList();
                return View("AllRoles", rolelist);
            }



            Roles newrole = new Roles();
            newrole.RoleName = Rolename;
            _context.Roles.Add(newrole);
            _context.SaveChanges();
            var newroleid = _context.Roles.FirstOrDefault(r => r.RoleName == Rolename).RoleId;
           

            if(perone != null)
            {
                roleDal.addperTorole(newroleid, 1);
            }
            if (pertwo != null)
            {
                roleDal.addperTorole(newroleid, 2);
            }
            if (perthree != null)
            {
                roleDal.addperTorole(newroleid, 3);
            }
            if (perfour != null)
            {
                roleDal.addperTorole(newroleid, 4);
            }
            if (perfive != null)
            {
                roleDal.addperTorole(newroleid, 5);
            }
            if (persix != null)
            {
                roleDal.addperTorole(newroleid, 6);
            }




            var rolelistt = _context.Roles.ToList();
            return View("AllRoles", rolelistt);
        }











    }
}