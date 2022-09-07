using MarketPricingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPricingSystem.Authorization
{
    public class customedashboardAuthorization : AuthorizeAttribute  
    {
        
        string [] allowedpermission;
      
        public customedashboardAuthorization(string permission)
        {
            this.allowedpermission = permission.Split(',').ToArray();
        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
           
                
            var a = this.allowedpermission;
           
            
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

    }
}