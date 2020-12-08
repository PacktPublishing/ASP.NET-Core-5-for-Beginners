using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Chapter_08_BasicAuth
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var username = "andreas";
            var password = "password";
            //Must be in 'username:password' format
            var byteEncoding = System.Text.UTF8Encoding.UTF8.GetBytes($"{username}:{password}");
            var credentials = Convert.ToBase64String(byteEncoding);
            
            Console.WriteLine($"Base64 encoded: {credentials}");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);    
            var response = await client.GetStringAsync("https://localhost:5001/Echo");

            Console.WriteLine($"Response: {response}");
        }        
    }
}
