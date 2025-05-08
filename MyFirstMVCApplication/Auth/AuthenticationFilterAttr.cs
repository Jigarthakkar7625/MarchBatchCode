using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MyFirstMVCApplication.Auth
{
    public class AuthenticationFilterAttr : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            // User password >> Is Authenticated or not

            // NOT VALID

            filterContext.Result = new HttpUnauthorizedResult();
            //throw new NotImplementedException();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // unauthentication >> Login > No its not proper

            filterContext.Result = new RedirectResult("~/Controller/Login");

            //throw new NotImplementedException();
        }
    }
}