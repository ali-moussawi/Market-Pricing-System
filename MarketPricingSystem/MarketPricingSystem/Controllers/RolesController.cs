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

            var rolelist = _context.Roles.Where(r=>r.RoleName!="Admin").ToList();

            return View(rolelist);

        }



      


        public ActionResult Rolepermissions(int id)
        {
            IEnumerable<Permissions> permissions = roleDal.Rolepermission(id);

            return View(permissions);
        }




        public ActionResult Createrole()
        {
            var allpermissions = _context.Permissions.ToList();

            return View(allpermissions);
        }


        [HttpPost]
        public ActionResult ConfirmCreate(string Rolename, int? viewsupermarket, int? addsupermarket, int? updatesupermarket, int? deletesupermarket, int? viewproduct, int? addproduct   , int? updateproduct, int? deleteproduct , int? viewcategory, int? addcategory, int? updatecategory , int? deletecategory, int? viewroles, int? createrole , int? viewpermissions , int? viewusers , int? adduser , int? updateuser , int? deleteuser)
        {

            var checkdb = _context.Roles.FirstOrDefault(c => c.RoleName == Rolename);
            if (checkdb != null)
            {
                var rolelist = _context.Roles.ToList();
                return RedirectToAction("AllRoles", rolelist);
            }



            Roles newrole = new Roles();
            newrole.RoleName = Rolename;
            _context.Roles.Add(newrole);
            _context.SaveChanges();



            var newroleid = _context.Roles.FirstOrDefault(r => r.RoleName == Rolename).RoleId;
           
            if(viewsupermarket != null)
            {
                roleDal.addperTorole(newroleid, viewsupermarket.Value);

            }           
            if(addsupermarket != null)
            {
                roleDal.addperTorole(newroleid, addsupermarket.Value);

            }           
            if(updatesupermarket != null)
            {
                roleDal.addperTorole(newroleid, updatesupermarket.Value);

            }           
            if(deletesupermarket != null)
            {
                roleDal.addperTorole(newroleid, deletesupermarket.Value);

            }           
            if(viewproduct != null)
            {
                roleDal.addperTorole(newroleid, viewproduct.Value);

            }           
            if(addproduct != null)
            {
                roleDal.addperTorole(newroleid, addproduct.Value);

            }           
            if(updateproduct != null)
            {
                roleDal.addperTorole(newroleid, updateproduct.Value);

            }           
            if(deleteproduct != null)
            {
                roleDal.addperTorole(newroleid, deleteproduct.Value);

            }           
            if(viewcategory != null)
            {
                roleDal.addperTorole(newroleid, viewcategory.Value);

            }           
            if(addcategory != null)
            {
                roleDal.addperTorole(newroleid, addcategory.Value);

            }           
            if(updatecategory != null)
            {
                roleDal.addperTorole(newroleid, updatecategory.Value);

            }           
            if(deletecategory != null)
            {
                roleDal.addperTorole(newroleid, deletecategory.Value);

            }           
            if(viewroles != null)
            {
                roleDal.addperTorole(newroleid, viewroles.Value);

            }           
            if(createrole != null)
            {
                roleDal.addperTorole(newroleid, createrole.Value);

            }           
            if(viewpermissions != null)
            {
                roleDal.addperTorole(newroleid, viewpermissions.Value);

            }           
            if(viewusers != null)
            {
                roleDal.addperTorole(newroleid, viewusers.Value);

            }           
            if(adduser != null)
            {
                roleDal.addperTorole(newroleid, adduser.Value);

            }           
            if(updateuser != null)
            {
                roleDal.addperTorole(newroleid, updateuser.Value);

            }           
            if(deleteuser != null)
            {
                roleDal.addperTorole(newroleid, deleteuser.Value);

            }







            var rolelistt = _context.Roles.ToList();
            return RedirectToAction("AllRoles", rolelistt);
        }











    }
}