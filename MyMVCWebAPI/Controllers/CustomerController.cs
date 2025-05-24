using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
//using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace MyMVCWebAPI.Controllers
{
    // 2 Type
    // Convenstional Routing
    // Attribute Routing

    [RoutePrefix("api/CustomerJigar")] //APi/Controller
    public class CustomerController : ApiController
    {
        // ? // Nullable
        // ??
        [Route("Login")]
        [HttpGet]
        public IHttpActionResult Login()
        {

            // Username and password >> Database ma check karvanu and user na data pass karvana 
            var getToken = Token();
            //var getToken = Token(User);
            return Ok(getToken);

        }

        public object Token()
        {
            string key = "E9DB7E89123F52A9F2DB04EF04C7FE88";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var issuer = "https://localhost:44318";
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var listOfClain = new List<Claim>();
            listOfClain.Add(new Claim("UserName", "jigar Thakkar"));
            listOfClain.Add(new Claim(ClaimTypes.Role, "User"));

            var token = new JwtSecurityToken(issuer,
                issuer, 
                listOfClain,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
             );


            var generateToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new { token = generateToken };
        }


        //{} >> Attribute Routing
        //[Route("GetCustomerData/{id}")] //Action name change kari sako
        //[Route("GetCustomerData/{id:int}")]
        //[Route("GetCustomerData/{name:alpha}")]
        //[Route("GetCustomerData/{id:int?}")]
        [Route("GetCustomerData/{id}/Hello/{name}")]
        [Route("GetCustomerData/{id}/{name}")]
        public IHttpActionResult GetData(int id, string name)
        {
            int? a = 10;

            int b = a ?? 0;

            // int b = a == null ? 0 : a;

            //if (a == null)
            //{
            //    b = 0;
            //}
            //else
            //{
            //    b = a;
            //}

            List<int> ints = new List<int> { 1, 2, 3, 5, 6, 9 };
            return Ok(ints);
        }

        public IHttpActionResult GetMyData()
        {
            List<int> ints = new List<int> { 1, 2, 3, 5, 6, 9 };
            return Ok(ints);
        }
    }
}

//Oauth
//    Jwt