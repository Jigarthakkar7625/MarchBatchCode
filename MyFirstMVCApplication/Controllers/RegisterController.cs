using MyFirstMVCApplication.Auth;
using MyFirstMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        // FILTERS >> VVVM

        //Authentication > Check if user exist or not in our system
        //Authorization > Roles and rights(Admin, HR, User, Customer, Seller)
        // [Authorize]
        //Action Filer >>> Most IMP
        //Exception Filter >> Most IMP
        // REsult filter
        //[Authorize] // Attribute


        //[AuthenticationFilterAttr]
        //[AuthorizationFilterAttr("Admin, HR")]
        [ActionFilterAttr]
        [HttpGet] // Data Get
        public ActionResult Index()
        {


            using (var myContext = new MyDBJMAAEntities())

            {
                // var getData = myContext.Users.ToList();    // READ DATA GET

                // Insert the record


                //var user = new User();
                //user.UserId = 252;
                //user.UserName = "Harsh";
                //user.IsActive = true;
                //user.Salary = 50;
                //user.Department = "IT";
                //user.Gender = 2;

                // ADD
                //var departmentID = new DepartmentID();

                //departmentID.DepartmentId1 = 1;
                //departmentID.DepartmentName = "name";

                //myContext.DepartmentIDs.Add(departmentID);
                //myContext.SaveChanges(); // Database ma save thase


                // Update

                //var getData = myContext.DepartmentIDs.Where(x => x.DepartmentId1 == 4).FirstOrDefault();

                //var getData = myContext.DepartmentIDs.FirstOrDefault(x => x.DepartmentId1 == 4);

                //if (getData != null)
                //{
                //    getData.DepartmentName = "name12212212121";
                //    myContext.SaveChanges(); // Database ma save thase
                //}

                var getData = myContext.DepartmentIDs.FirstOrDefault(x => x.DepartmentId1 == 5);
                if (getData != null)
                {
                    myContext.DepartmentIDs.Remove(getData);
                    myContext.SaveChanges();

                }


            }


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
        public ActionResult Save(RegisterModel registerModel, HttpPostedFileBase httpPostedFile)
        {
            // Login >
            // Database Check username and password
            // User >> Session store

            if (httpPostedFile != null && httpPostedFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(httpPostedFile.FileName);
                string path = Server.MapPath("~/Files/" + fileName);

                //httpPostedFile.

                //httpPostedFile.SaveAs(path);

            }

            // FileID PK
            // FileName
            // ContentType 
            // FileSize
            // FilePath
            // FileUploadDDate
            // UserId >> FK (10)




            Session["UserId"] = 10;
            Session["Email"] = registerModel.Email;


            HttpCookie httpCookie = new HttpCookie("UserId", "10");
            httpCookie.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(httpCookie);

            //RegisterModel registerModel = new RegisterModel();
            //registerModel.FirstName = "Jigar";
            //Save into database
            return RedirectToAction("About", "Home");
        }
    }
}