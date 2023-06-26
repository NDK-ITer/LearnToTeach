using Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
                
        public IActionResult Index()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:9000");
            var respone = client.GetAsync("/classroom/all").Result;
            // check authenticate
            if (respone.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //unless client authenticated
                return RedirectToAction("Login", "Authentication");
            }
            // if client authenticated
            string jsonData = respone.Content.ReadAsStringAsync().Result;
            //transf JSON data to Object data
            List<ClassroomModel> classData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ClassroomModel>>(jsonData);

            return View(classData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}