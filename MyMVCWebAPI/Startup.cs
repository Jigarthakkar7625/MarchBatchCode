using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using MyMVCWebAPI.Provider;
using Microsoft.Owin.Host.SystemWeb;


[assembly: OwinStartup(typeof(MyMVCWebAPI.Startup))]

namespace MyMVCWebAPI
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            //PublicClientId = "self";

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://localhost:44318",
                        ValidateAudience = true,
                        ValidAudience = "https://localhost:44318",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("E9DB7E89123F52A9F2DB04EF04C7FE88")),
                        

                    }
                }

            );


            //OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/Token"), // Path
            //    Provider = new OAuthProvider(),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            //    AllowInsecureHttp = true,
            //};

            //app.UseOAuthBearerTokens(OAuthOptions);
           // app.UseOAuthAuthorizationServer(OAuthOptions);

        }
    }
}
