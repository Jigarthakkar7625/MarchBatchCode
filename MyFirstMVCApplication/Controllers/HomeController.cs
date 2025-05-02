using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var getData = TempData["Message"];

            var username = Session["Email"];

            var cookie = Request.Cookies["UserId"].Value;
            //TempData.Keep();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var getData = TempData["Message"];
            ViewBag.Message = "Your contact page.";
            //TempData.Keep();


            return View();
        }
    }
}