using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Chapter_08_BearerAuthServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EchoController : ControllerBase
    {
        [HttpGet]
        public String Get()
        {            
            var audience = "Chapter_08_BearerAuth";
            var issuer = "Chapter 08";

            var authHeader = HttpContext.Request.Headers["Authorization"];
            var base64Token = AuthenticationHeaderValue.Parse(authHeader).Parameter;
            
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = null;

            validationParameters =
                new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    //Needed to force disabling signature validation                        
                    SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                    {
                        var jwt = new JwtSecurityToken(token);
                        return jwt;
                    },                        
                    ValidateIssuerSigningKey = false,                   
                };

            try
            {
                SecurityToken validatedToken;                
                var identity = handler.ValidateToken(base64Token, validationParameters, out validatedToken);
                return "Token is valid!";   
            }
            catch (Exception e)
            {
               return $"Token failed to validate:  {e.Message}";
            }
        }
    }
}