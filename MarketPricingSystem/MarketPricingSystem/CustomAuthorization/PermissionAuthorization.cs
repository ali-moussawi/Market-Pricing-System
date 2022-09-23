using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPricingSystem.Models;
namespace MarketPricingSystem.CustomAuthorization
{



    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PermissionAuthorization :AuthorizeAttribute
    {
         private marketpricingContext _context =new marketpricingContext();

        
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthorized = base.AuthorizeCore(httpContext);

            var userrole = httpContext.User.Identity.Name.Split(',')[1];
            var roleid = _context.Roles.FirstOrDefault(r => r.RoleName == userrole).RoleId;
            var allpermissionsid = _context.Rolepermissions.Where(rp => rp.RoleId == roleid).ToList();


            List<MarketPricingSystem.Models.Permissions> permissions= new List<MarketPricingSystem.Models.Permissions>();

            foreach(var target in allpermissionsid)
            {
                var targetid = target.PermissionId;
              
                permissions.Add(_context.Permissions.FirstOrDefault(p => p.PermissionId == targetid));
            }
            //now we have all permissions of the user that have this role;

            var targetpermissions = permissions.FirstOrDefault( p=>p.PermissionName == Roles);

            if(targetpermissions != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}