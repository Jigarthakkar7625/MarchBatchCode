using MyFirstMVCApplication.Auth;
using MyFirstMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        // Return VIew()
        //PartialView() -- DONE
        // JsonREsult() -- DONE
        //ContentResult()  -- DONE
        // RedirectResult() --DONE
        // RedirectActionResult() -- Done
        // File Result()
        // Emptry Result()


        public RedirectResult RedirectURL()
        {
            return Redirect("https://www.showits.tech/");

        }

        public ActionResult RedirectToActionResult()
        {
            return RedirectToAction("ActionName", "ControllerName");
        }

        //[ExceptionFilterAttr]
        [ResultFilterAttr]
        public ActionResult Index()
        {
            //int a = 0;
            //int b = 10;
            //var result = b / a;


            Session["Roles"] = "Admin"; //Frim DB


            List<UserModel> userModel = new List<UserModel> { new UserModel() { UserID = 1, UserName = "Jigar" },
             new UserModel() { UserID = 1, UserName = "Himani" },
            new UserModel() { UserID = 1, UserName = "Hitaxi" }};



            // Controller to View >> MODEL
            // State management >> Viewbag, ViewData and TempData

            // Controller TO view
            ViewBag.UserList = userModel;
            ViewBag.UserList1 = "jigar"; // NO CASTING
            //ViewBag.UserList2 = userModel;
            //ViewBag.UserList3 = userModel;
            //ViewBag.UserList4 = userModel;
            //ViewBag.UserList5 = userModel;
            //ViewBag.UserList6 = userModel;

            // Key, Value like dictionary
            // Type casting needed

            List<string> strings = new List<string> { "Apple", "Orange" };
            ViewData["Message"] = userModel;

            // TempDataa>> Controller to controller



            return View(userModel);
        }

        public ContentResult GetText()
        {
            return Content("JKfdsf");

        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            TempData["Message"] = "Message1212121";

            return RedirectToAction("About", "Home");
        }


        public JsonResult GetData()
        {
            List<UserModel> userModel = new List<UserModel> { new UserModel() { UserID = 1, UserName = "Jigar" },
             new UserModel() { UserID = 1, UserName = "Himani" },
            new UserModel() { UserID = 1, UserName = "Hitaxi" }};

            return Json(userModel, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult MyPartialView()
        {
            UserModel userModel = new UserModel();
            userModel.UserID = 1;
            return PartialView("MyPartialView", userModel);
        }


        public FileResult DownloadFile()
        {
            var getFullPath = Server.MapPath("~/Files/Khushi_Data_Analyst.pdf");

            byte[] fileByte = System.IO.File.ReadAllBytes(getFullPath);

            return File(fileByte, "application/pdf", "Khushi.pdf");

        }

        public ActionResult DoNothing()
        {
            return new EmptyResult();
        }



        // Json >> 


    }
}