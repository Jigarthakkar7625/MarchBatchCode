using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace MyMVCWebAPI.Provider
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Username and Password >> context
            using (var db = new MyDBJMAAEntities1())
            {
                var list = db.Users.ToList();

                if (list != null)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(list.Where(x => x.UserName == context.UserName && x.Department == context.Password).FirstOrDefault().UserName))
                        {
                            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                            identity.AddClaim(new Claim("UserName", context.UserName));
                            identity.AddClaim(new Claim("Age", "16"));
                            context.Validated(identity);

                        }
                    }
                    catch (Exception)
                    {
                        context.SetError("Invalid", "Username or password is invalid");
                        context.Rejected();
                        //throw;
                    }
                }

                return;

            }
        }
    }
}