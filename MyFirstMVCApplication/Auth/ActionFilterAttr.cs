using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Auth
{
    public class ActionFilterAttr : FilterAttribute, IActionFilter
    {
        //After my action method called
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //filterContext.Result = ......
         
            //throw new NotImplementedException();
        }
        // Before My Controler Action Method call
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if()
            filterContext.Controller.ViewBag.Name = "JKgarfsdf";
            filterContext.HttpContext.Session["UserName"] = "hfkskfks";

            //throw new NotImplementedException();
        }
    }
}