using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Chapter_07_BasicAuthServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EchoController : ControllerBase
    {
        [HttpGet]
        public String Get()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"];
            var base64Creds = AuthenticationHeaderValue.Parse(authHeader).Parameter;
            var byteEncoded = System.Convert.FromBase64String(base64Creds);
            var credentials = System.Text.Encoding.UTF8.GetString(byteEncoded);       

            if (credentials
                == "andreas:password")
            {
                return "Hello Andreas";
            }
            else
            {
                return "You didn't pass authentication!";
            }            
        }
    }
}
