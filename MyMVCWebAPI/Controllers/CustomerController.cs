using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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