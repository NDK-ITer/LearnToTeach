using ClienWebDemo;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Text;
using System.Text.Json;

namespace Demo.Controllers
{
    public class AuthenticateController : Controller
    {
        public IActionResult Login(string username, string password)
        {
            var loginModel = new Login
            {
                Username = username,
                Password = password
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:9000");

            var json = JsonSerializer.Serialize(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var respone = client.PostAsync("/account/login",content).Result;
            string jsonData = respone.Content.ReadAsStringAsync().Result;
            AuthenticationReponse authenticationReponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthenticationReponse>(jsonData);
            //if (authenticationReponse.JwtToken != null)
            //{
            //    CookieOptions options = new CookieOptions()
            //    {
            //        Expires = DateTime.Now.AddMinutes(authenticationReponse.ExpiresIn)
            //    };
            //    Response.Cookies.Append("AuthenticationToken", authenticationReponse.JwtToken, options);
            //}
            if (!string.IsNullOrEmpty(authenticationReponse.JwtToken)) 
            {
                Response.Cookies.Append(
                NameToken.NameOfAuthenticateToken,
                authenticationReponse.JwtToken, 
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });
                return RedirectToAction("Index","Home");
            }
            return View();

        }
    }
}
