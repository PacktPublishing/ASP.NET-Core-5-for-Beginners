using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Chapter_08_BearerAuthClient
{
    class Program
    {
        private static Lazy<X509SigningCredentials> SigningCredentials;
        protected static string SigningCertThumbprint = "thumbprint";

        public static GenericToken jwt { get; set; }
        public static string output = "";

        static void Main(string[] args)
        {
            jwt = new GenericToken
            {
                Audience = "Chapter_08_BearerAuth",
                IssuedAt = DateTime.UtcNow.ToString(),
                iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                Expiration = DateTime.UtcNow.AddMinutes(60).ToString(),
                exp = DateTimeOffset.UtcNow.AddMinutes(60).ToUnixTimeSeconds().ToString(),
                Issuer = "Chapter 08",
                Subject = "john.doe@contoso.com",
            };

            SigningCredentials = new Lazy<X509SigningCredentials>(() =>
            {
                X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                certStore.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certCollection = certStore.Certificates.Find(
                                            X509FindType.FindByThumbprint,
                                            SigningCertThumbprint,
                                            false);
            // Get the first cert with the thumbprint
            if (certCollection.Count > 0)
                {
                    return new X509SigningCredentials(certCollection[0]);
                }

                throw new Exception("Certificate not found");
            });

            IList<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim>();
            claims.Add(new System.Security.Claims.Claim("sub", jwt.Subject, System.Security.Claims.ClaimValueTypes.String, jwt.Issuer));

            // Create the token
            JwtSecurityToken token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,                    
                    DateTime.UtcNow,                    
                    DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials.Value);

            // Get the string representation of the signed token and print it
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            output = jwtHandler.WriteToken(token);
            Console.WriteLine($"Token: {output}");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", output);
            var response = client.GetAsync("https://localhost:5001/Echo").Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result.ToString());
        }
    }

    public class GenericToken
    {
        public string Issuer { get; set; }
        public string IssuedAt { get; set; }
        public string iat { get; set; }
        public string Expiration { get; set; }
        public string exp { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

    }
}
