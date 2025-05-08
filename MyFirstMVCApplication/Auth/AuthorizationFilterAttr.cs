using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace MyFirstMVCApplication.Auth
{
    public class AuthorizationFilterAttr : ActionFilterAttribute, IAuthorizationFilter
    {

        // Login > User pass >> check Database > Roles Session >

        private string _roles;
        public AuthorizationFilterAttr(string roles)
        {
            _roles = roles;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // Login > UserName and password > If valid >> From Database Roles (Admin)


            var getRoles = Convert.ToString(filterContext.HttpContext.Session["Roles"]);

            var checkRoles = _roles.Contains(getRoles); // Checking

            if (!checkRoles)
            {
                filterContext.HttpContext.Session.Abandon();
                filterContext.HttpContext.Session.Clear();

                //filterContext.Result = new RedirectResult(""); // Login
                filterContext.Result = new HttpUnauthorizedResult();
            }


            // Login > 
            // Login and roles
            //throw new NotImplementedException();
        }
    }
}