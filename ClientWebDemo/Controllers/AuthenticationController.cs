using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Demo.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login(string username, string password)
        {
            var loginModel = new LoginModel
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
            return View();
        }
    }
}
