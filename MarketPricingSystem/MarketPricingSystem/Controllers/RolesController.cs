using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.DAL;
using MarketPricingSystem.ViewModel;
using Microsoft.EntityFrameworkCore;
using MarketPricingSystem.CustomAuthorization;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MarketPricingSystem.Controllers
{
    [Authorize]
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



        [PermissionAuthorization(Roles = "viewroles")]
        public ActionResult AllRoles()
        {

            var rolelist = _context.Roles.Where(r=>r.RoleName !="Admin" && r.RoleName != "temprole").ToList();

            return View(rolelist);

        }



      


        public ActionResult Rolepermissions(int id)
        {
            IEnumerable<Permissions> permissions = roleDal.Rolepermission(id);

            return View(permissions);
        }









        [PermissionAuthorization(Roles = "createrole")]
        public ActionResult Createrole()
        {
            var allpermissions = _context.Permissions.ToList();

            return View(allpermissions);
        }

        [PermissionAuthorization(Roles = "createrole")]
        [HttpPost]
        public ActionResult ConfirmCreate(string Rolename, int? viewsupermarket, int? addsupermarket, int? updatesupermarket, int? deletesupermarket, int? viewproduct, int? addproduct   , int? updateproduct, int? deleteproduct , int? viewcategory, int? addcategory, int? updatecategory , int? deletecategory, int? viewroles, int? createrole , int? viewpermissions , int? viewusers , int? adduser , int? updateuser , int? deleteuser, int? updaterole, int? viewsp, int? viewspp, int? insertproducts, int? updateproductprice, int? deleteproductpriced)
        {

            var checkdb = _context.Roles.FirstOrDefault(c => c.RoleName == Rolename);
            if (checkdb != null)
            {
                TempData["Message1"] = "Role already Exists"; 

                return RedirectToAction("Createrole");
            }



           MarketPricingSystem.Models.Roles newrole = new MarketPricingSystem.Models.Roles();
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

            ////////////////////////////////////////////////new permissions

            if (updaterole != null)
            {
                roleDal.addperTorole(newroleid, updaterole.Value);

            }




            if (viewsp != null)
            {
                roleDal.addperTorole(newroleid, viewsp.Value);

            }



            if (viewspp != null)
            {
                roleDal.addperTorole(newroleid, viewspp.Value);

            }


                if (insertproducts != null)
            {
                roleDal.addperTorole(newroleid, insertproducts.Value);

            }



            if (updateproductprice != null)
            {
                roleDal.addperTorole(newroleid, updateproductprice.Value);

            }



            if (deleteproductpriced != null)
            {
                roleDal.addperTorole(newroleid, deleteproductpriced.Value);

            }





            var rolelistt = _context.Roles.ToList();
            return RedirectToAction("AllRoles", rolelistt);
        }















        [PermissionAuthorization(Roles = "updaterole")]
        public ActionResult Updaterole(int id)
        {


            roleandpermissionsandcheckedone data = new roleandpermissionsandcheckedone();

            data.role = _context.Roles.FirstOrDefault(r=>r.RoleId==id);
            data.permissions = _context.Permissions.ToList();
            data.checkedpermissionsid = _context.Rolepermissions.Where(r=>r.RoleId == id).ToList();
           

            return View(data);

        }


        [PermissionAuthorization(Roles = "updaterole")]
        [HttpPost]
        public ActionResult Confirmupdate(int roleid, string Rolename, int? viewsupermarket, int? addsupermarket, int? updatesupermarket, int? deletesupermarket, int? viewproduct, int? addproduct, int? updateproduct, int? deleteproduct, int? viewcategory, int? addcategory, int? updatecategory, int? deletecategory, int? viewroles, int? createrole, int? viewpermissions, int? viewusers, int? adduser, int? updateuser, int? deleteuser, int? updaterole, int? viewsp, int? viewspp, int? insertproducts, int? updateproductprice, int? deleteproductpriced)
        {
            var targetrole = _context.Roles.FirstOrDefault(r => r.RoleId == roleid);
            if(targetrole.RoleName != Rolename)
            {
                var checkdb = _context.Roles.FirstOrDefault(c => c.RoleName == Rolename);
                if (checkdb != null)
                {
                    TempData["Message1"] = "Role already Exists";

                    return RedirectToAction("Updaterole", new { @id= targetrole.RoleId});
                }
            }

            targetrole.RoleName = Rolename;
            _context.SaveChanges();
            //we use name space becuase we have two refereneces of same name but namespace cannot be duplicated so it help to avoid ambiguos refereneces;
           MarketPricingSystem.Models.Roles newrole = new MarketPricingSystem.Models.Roles();
            newrole.RoleName = targetrole.RoleName;
            newrole.RoleId = targetrole.RoleId;


            var rolepermissions = _context.Rolepermissions.Where(r => r.RoleId == roleid).ToList();

            foreach(var row in rolepermissions)
            {
                _context.Rolepermissions.Remove(row);
                _context.SaveChanges();
            }

            var usersofrole = _context.Users.Where(u => u.Roleid == roleid).ToList();

            foreach (var row2 in usersofrole)
            {
                row2.Roleid = _context.Roles.FirstOrDefault(r=>r.RoleName== "Temprole").RoleId;
                _context.SaveChanges();
            }


            _context.Roles.Remove(targetrole);
            _context.SaveChanges();

            _context.Roles.Add(newrole);
            _context.SaveChanges();

            foreach (var row2 in usersofrole)
            {
                row2.Roleid = newrole.RoleId;
                _context.SaveChanges();
            }


            var newroleid = roleid;

            if (viewsupermarket != null)
            {
                roleDal.addperTorole(newroleid, viewsupermarket.Value);

            }
            if (addsupermarket != null)
            {
                roleDal.addperTorole(newroleid, addsupermarket.Value);

            }
            if (updatesupermarket != null)
            {
                roleDal.addperTorole(newroleid, updatesupermarket.Value);

            }
            if (deletesupermarket != null)
            {
                roleDal.addperTorole(newroleid, deletesupermarket.Value);

            }
            if (viewproduct != null)
            {
                roleDal.addperTorole(newroleid, viewproduct.Value);

            }
            if (addproduct != null)
            {
                roleDal.addperTorole(newroleid, addproduct.Value);

            }
            if (updateproduct != null)
            {
                roleDal.addperTorole(newroleid, updateproduct.Value);

            }
            if (deleteproduct != null)
            {
                roleDal.addperTorole(newroleid, deleteproduct.Value);

            }
            if (viewcategory != null)
            {
                roleDal.addperTorole(newroleid, viewcategory.Value);

            }
            if (addcategory != null)
            {
                roleDal.addperTorole(newroleid, addcategory.Value);

            }
            if (updatecategory != null)
            {
                roleDal.addperTorole(newroleid, updatecategory.Value);

            }
            if (deletecategory != null)
            {
                roleDal.addperTorole(newroleid, deletecategory.Value);

            }
            if (viewroles != null)
            {
                roleDal.addperTorole(newroleid, viewroles.Value);

            }
            if (createrole != null)
            {
                roleDal.addperTorole(newroleid, createrole.Value);

            }
            if (viewpermissions != null)
            {
                roleDal.addperTorole(newroleid, viewpermissions.Value);

            }
            if (viewusers != null)
            {
                roleDal.addperTorole(newroleid, viewusers.Value);

            }
            if (adduser != null)
            {
                roleDal.addperTorole(newroleid, adduser.Value);

            }
            if (updateuser != null)
            {
                roleDal.addperTorole(newroleid, updateuser.Value);

            }
            if (deleteuser != null)
            {
                roleDal.addperTorole(newroleid, deleteuser.Value);

            }



            ////////////////////////////////////////////////new permissions

            if (updaterole != null)
            {
                roleDal.addperTorole(newroleid, updaterole.Value);
            }




            if (viewsp != null)
            {
                roleDal.addperTorole(newroleid, viewsp.Value);

            }



            if (viewspp != null)
            {
                roleDal.addperTorole(newroleid, viewspp.Value);

            }


            if (insertproducts != null)
            {
                roleDal.addperTorole(newroleid, insertproducts.Value);

            }



            if (updateproductprice != null)
            {
                roleDal.addperTorole(newroleid, updateproductprice.Value);

            }



            if (deleteproductpriced != null)
            {
                roleDal.addperTorole(newroleid, deleteproductpriced.Value);

            }


            var rolelistt = _context.Roles.ToList();
            return RedirectToAction("AllRoles", rolelistt);
        }






    }
}