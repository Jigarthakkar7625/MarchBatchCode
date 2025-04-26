using MyFirstMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        [HttpGet] // Data Get
        public ActionResult Index()
        {
            RegisterModel registerModel = new RegisterModel();
            registerModel.FirstName = "Jigar";
            return View(registerModel);
        }

        [HttpPost] // Data save
        public ActionResult Index(RegisterModel registerModel)
        {
            //RegisterModel registerModel = new RegisterModel();
            //registerModel.FirstName = "Jigar";
            //Save into database
            return View(registerModel);
        }
    }
}