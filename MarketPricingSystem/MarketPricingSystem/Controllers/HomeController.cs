using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPricingSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult validatesignin()
        {
            return View();
        }

    }
}