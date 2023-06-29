using Demo.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using System.Text.Json;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("ApiGateway");
            var httpResponseMessage = await httpClient.GetAsync("/classroom/all");
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Authenticate");
            }
            string jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var classData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Classroom>>(jsonData);
            return View(classData);
        }

        public async Task<IActionResult> Privacy()
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