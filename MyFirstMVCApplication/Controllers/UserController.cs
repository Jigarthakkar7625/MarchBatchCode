using MyFirstMVCApplication.Auth;
using MyFirstMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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


        private static void GetChangeTracker(DbChangeTracker changeTracker)
        {
            var entity = changeTracker.Entries();

            foreach (var item in entity)
            {
                var getName = item.Entity.GetType().FullName;
                var State = item.State;

            }

        }

        //[ExceptionFilterAttr]
        //[ResultFilterAttr]
        public ActionResult Index()

        {
            //ef 6 
            MyDBJMAAEntities myDBJMAAEntities = new MyDBJMAAEntities();

            // Using EF >> Inline SQL query
            int getIntID = myDBJMAAEntities.Database.ExecuteSqlCommand("Insert into [dbo].[User_Address] values('My Data', 4)");

            int getIntIDs = myDBJMAAEntities.Database.ExecuteSqlCommand("Update .....");

            int getIntIDssd = myDBJMAAEntities.Database.ExecuteSqlCommand("Delete From tableName where.....");


            //var abcdsds = myDBJMAAEntities.Students.SqlQuery("Select * from Student where StudentId = 5").ToList();

            // EF : 3 Approach : Database first, Code first and Model first
            //  I, U, D, R > 

            //Eager loading and Lazy loading

            // Eager loading
            var abcd = myDBJMAAEntities.Students.Include("Course").ToList();
            // Jetla record che e badha ni andar course malse

            //Lazy loading
            var abcdcc = myDBJMAAEntities.Students.ToList();

            Course students = abcdcc[0].Course; //Specific one record no j course malse


            // Disadvantages >> 


            //var getData123 = myDBJMAAEntities.Users.Find(1);


            List<User> users = new List<User>()
            {
                new User(){UserName = "Jigar" },
                new User(){UserName = "Jigarsdfdas" },
                new User(){UserName = "Jigarsdfdas" }
            };

            myDBJMAAEntities.Users.AddRange(users); // Multile entries

            myDBJMAAEntities.Users.RemoveRange(users);

            var abc = myDBJMAAEntities.MyFirstSP(1);

            var result = myDBJMAAEntities.Database.ExecuteSqlCommand("EXEC MyFirstSP(1)");

            var resultS = myDBJMAAEntities.Database.SqlQuery<User>("EXEC MyFirstSP(1)").ToList();

            //foreach (var item in users)
            //{
            //    myDBJMAAEntities.Users.Add(item);
            //}



            ////getData123.UserName = "fkjdshfjksddk";
            //myDBJMAAEntities.Users.Remove(getData123);


            //GetChangeTracker(myDBJMAAEntities.ChangeTracker);


            //



            using (var trans = myDBJMAAEntities.Database.BeginTransaction()) // Advanrtages
            {
                try
                {
                    // myDBJMAAEntities.User_Address.Add();
                    myDBJMAAEntities.SaveChanges();
                    // myDBJMAAEntities.Users.Add();
                    myDBJMAAEntities.SaveChanges(); // ERROR
                    // Delete
                    myDBJMAAEntities.SaveChanges();


                    trans.Commit();


                    // Authentication >> JWT and Aspnet identity


                }
                catch (Exception)
                {
                    trans.Rollback();
                    //throw;
                }


                // Will automatically dispose 
            }


            // EF > GET, Update, Delete, New record added (CRUD)





            // IEn
            // In memory >> All data gets, after that we can do filters
            // LINQ to Object
            List<string> names = new List<string> { "a", "b", "c" }; // From database
            IEnumerable<string> result = names.Where(x => x.StartsWith("a")).ToList();

            // Out memory
            // LINQ to EF (SQL)
            var names1 = myDBJMAAEntities.Students.Where(x => x.Address == "");

            //
            // and IQ


            // JOINS : 
            // INNER JOIN
            //Select * from [dbo].[Student] s
            //inner join[dbo].[StudentAddress] sa on sa.StudentId = s.StudentId
            //var getDataJoins = (from s in myDBJMAAEntities.Students
            //                    join sa in myDBJMAAEntities.StudentAddresses on s.StudentId equals sa.StudentId
            //                    //join sa in myDBJMAAEntities.StudentAddresses on s.StudentId equals sa.StudentId
            //                    //join sa in myDBJMAAEntities.StudentAddresses on s.StudentId equals sa.StudentId
            //                    //join sa in myDBJMAAEntities.StudentAddresses on s.StudentId equals sa.StudentId
            //                    //join sa in myDBJMAAEntities.StudentAddresses on s.StudentId equals sa.StudentId
            //                    select new { s.StudentId, s.StudentName, sa.StudentAddress1 }).ToList();


            //var getDataJoinsLeft = (from s in myDBJMAAEntities.Students
            //                    join sa in myDBJMAAEntities.StudentAddresses on s.StudentId equals sa.StudentId into saGroup
            //                        from saForam in saGroup.DefaultIfEmpty()

            //                        //join sa in myDBJMAAEntities.StudentAddresses on s.StudentId equals sa.StudentId into saGroup
            //                        //from saForam in saGroup.DefaultIfEmpty()

            //                        select new { s.StudentId, s.StudentName, saForam.StudentAddress1 }).ToList();

            //var getDataJoinsRight = (from s in myDBJMAAEntities.StudentAddresses
            //                         join sa in myDBJMAAEntities.Students on s.StudentId equals sa.StudentId into saGroup
            //                        from saForam in saGroup.DefaultIfEmpty()

            //                            //join sa in myDBJMAAEntities.StudentAddresses on s.StudentId equals sa.StudentId into saGroup
            //                            //from saForam in saGroup.DefaultIfEmpty()

            //                        select new { s.StudentId, s.StudentAddress1, saForam.StudentName }).ToList();


            // Cross Join
            var getDataCrossJoin = (from s in myDBJMAAEntities.Students
                                    from sa in myDBJMAAEntities.StudentAddresses
                                    select new { s.StudentId, s.StudentName, sa.StudentAddressId }).ToList();


            //on s.StudentId equals sa.StudentId
            //select new { s.StudentId, s.StudentName, sa.StudentAddress1 }).ToList();







            // ALL and ANY
            //
            var getDatasd = myDBJMAAEntities.AuditLogs.All(x => x.AuditLogId > 0);


            List<int> ints = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            // Element and elemetOrdEf
            var getIndexds = ints.ElementAtOrDefault(1);
            var getIndex11dsd = ints.ElementAtOrDefault(150);

            var getIndex = ints.ElementAt(20);
            var getIndex11 = ints.ElementAt(150);




            ints.Distinct();
            if (ints.Count() > 0)
            {

            }



            var getData = myDBJMAAEntities.Users.GroupBy(y => new { y.Department, y.UserName })
                .Select(x => new
                {
                    Department = x.Key.Department,
                    UserName = x.Key.UserName,
                    TotalSalary = x.Sum(y => y.Salary)

                }).ToList();

            // Take : 

            int pAGE = 2; // 0,1,2,
            int SIZE = 5;


            // Pagination
            var records = myDBJMAAEntities.Users.Skip((pAGE - 1) * SIZE).Take(SIZE).ToList();


            //var getFirst4Record = ints.Take(4).ToList();

            //var getFirst4Recordss = ints.TakeWhile(x => x < 50).ToList();


            //var getFirst4Recordsss = ints.Skip(4).ToList();

            //var getFirst4Recordssss = ints.Take(2).SkipWhile(x => x < 50).ToList();

            // Select top 4 * from tablename

            var getFirst4Record1 = ints.Where(x => x > 40).Take(4).ToList();


            var checkRecordssdas = ints.Contains(300);

            var checkRecords = ints.Any(x => x > 20);

            var checkRecordsww = ints.All(x => x > 20);

            var checkRecordswwdsa = ints.All(x => x > 5);


            //FirstOrDefault and First

            //List<int> ints = new List<int>() { 10, 20 };

            //// Should be only 1 record
            //var df21 = ints.SingleOrDefault(); /// NO Record  >> Default value, but nO error
            //var fds22 = ints.Single(); //Give the error if record is not exist

            //var df = ints.FirstOrDefault();
            //var fds = ints.First();

            //var df21 = ints.LastOrDefault(); /// NO Record  >> Default value, but nO error
            //var fds22 = ints.Last(); //Give the error if record is not exist

            var getDatasd444ds = myDBJMAAEntities.Users.FirstOrDefault(x => x.UserName == "dssadasdsa");

            var getDatasd444dsdfds = myDBJMAAEntities.Users.First(x => x.UserName == "dssadasdsa");



            // Method Syntex
            //var getData = myDBJMAAEntities.Users.Select(x => new User { 
            //    UserName = x.UserName,
            //    UserId = x.UserId
            //}).ToList();

            //Query : 
            //var getData = (from audit in myDBJMAAEntities.AuditLogs
            //               select audit.AuditLogId
            //               ).ToList();

            //var getDatasd = myDBJMAAEntities.AuditLogs.Select(x => new AuditLog()
            //{
            //    AuditLogId = x.AuditLogId,
            //    Text = x.Text
            //}).ToList();

            //var getData = from user in myDBJMAAEntities.Users
            //              where user.UserName == "Parth"
            //              select user;

            //var getDatasd1 = myDBJMAAEntities.Users.Where(x => x.UserName == "Parth").ToList();

            //var getDatasdff = (from user in myDBJMAAEntities.Users
            //                   orderby user.UserName descending ).ToList();





            //var getDatasd2 = myDBJMAAEntities.Users.OrderBy(x => x.UserName).ToList();
            //var getDatasd3 = myDBJMAAEntities.Users.OrderByDescending(x => x.UserName).ToList();

            // EF  to LINQ
            //var getDatasd444 = myDBJMAAEntities.Users.Sum(x => x.Salary);
            //var getDatasd444ds = myDBJMAAEntities.Users.Max(x => x.Salary);

            // Object to LINQ
            //List<int> ints = new List<int>() { 1, 2, 3, 5, 4, 8, 7, 9, 4, 5, 2 };
            //var abc = ints.Distinct().ToList();


            //List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //List<int> int11 = new List<int>() { 1, 3, 5, 8, 9, 10 };

            //// Except

            ////var data = int11.Except(ints).ToList();

            //var data = int11.Intersect(ints).ToList();

            //var datasds = int11.Union(ints).ToList();
            //var datasdsfdfs = int11.Concat(ints).ToList();

            //// {1 to 10 } > Union 
            //// union all




            var getDatasd444ddfsfs = myDBJMAAEntities.Users.Select(x => x.UserName).Distinct().ToList();

            //LINQ >> Language integrated Query 
            // C# > SQl > LINQ
            // WHERE >> WHERE LINQ
            // Top 1 >> FirstOrDefault

            //List >> 5 record >> SQL > LINQ

            // LINQ >
            // ADO.NET DATASET
            // EF
            // SQL 
            //XML
            //

            // LINQ >> 
            // Method Syntex , Query Syntex


            // Projection Operators > SELECT
            // Filter Operators  >> WHERE
            // Partitioning Operator > TAKE, SKIP, TAKEWHILE, SKIPWHILE
            // Ordering Operator > Orderby,......
            // Group Ope > Group by
            // Join Operator > JOIN
            // Set Operator >>> Distinct, UNIon, Intersect, Except
            // Conversion Ope > .LIST, Array()
            // Element Operator > First, FirstOrDef, Last, LastOrDef....
            // Qualifier operator > ANy, ALL, Contrain
            // Aggregate >> SUM, MAX, MIN....



            //int a = 0;
            //int b = 10;
            //var result = b / a;


            Session["Roles"] = "Admin"; //Frim DB


            List<UserModel> userModel = new List<UserModel> { new UserModel() { UserID = 1, UserName = "Jigar" },
             new UserModel() { UserID = 1, UserName = "Himani" },
            new UserModel() { UserID = 1, UserName = "Hitaxi" }};

            //userModel.ToList();

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