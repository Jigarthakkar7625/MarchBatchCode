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

            List<UserModel> userModel = new List<UserModel> { new UserModel() { UserID = 1, UserName = "Jigar" },
             new UserModel() { UserID = 2, UserName = "Himani" },
            new UserModel() { UserID = 3, UserName = "Hitaxi" },
            new UserModel() { UserID = 4, UserName = "Nishit" },
            new UserModel() { UserID = 5, UserName = "Foram" }};

            ViewBag.UserList = userModel;
            registerModel.UserList = userModel;

            return View(registerModel);
        }

        [HttpPost] // Data save
        public ActionResult Save(RegisterModel registerModel)
        {
            
            //RegisterModel registerModel = new RegisterModel();
            //registerModel.FirstName = "Jigar";
            //Save into database
            return View(registerModel);
        }
    }
}