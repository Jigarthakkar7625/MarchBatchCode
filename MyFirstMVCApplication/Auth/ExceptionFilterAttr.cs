using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Auth
{
    public class ExceptionFilterAttr :FilterAttribute ,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            // 1 filter
            // Database / Text log file store 


            //throw new NotImplementedException();
        }
    }
}