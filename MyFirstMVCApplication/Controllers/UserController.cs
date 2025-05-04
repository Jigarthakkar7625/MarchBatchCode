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

        public ActionResult Index()
        {



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
        // Json >> 


    }
}