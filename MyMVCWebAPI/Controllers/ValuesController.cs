using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyMVCWebAPI.Controllers
{

    //RESTFUL >  Representational State Tranfer  >> 

    // GET >> Data retrive
    // POST >> CREATE > Insert >> New record
    // PUT >> entire DATA Update 
    // PATCH >> Partially >> 1 ke 2 field Update
    // DELETE >> Delete record

    [Authorize(Roles = "User")]
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        //[AllowAnonymous]
        //[Route("GetErrorResult")]
        // GET api/values


        [Route("GetItemdata")]
        [HttpGet]
        public IHttpActionResult GetItemdata()
        {

            // Username and password >> Database ma check karvanu and user na data pass karvana 
            //var getToken = Token();
            //var getToken = Token(User);
            return Ok();

        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        [HttpPut]
        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
