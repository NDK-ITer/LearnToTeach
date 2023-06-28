using ClienWebDemo.Services;
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
        private readonly IClassroomService _classroomService;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, IClassroomService classroomService)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _classroomService = classroomService;
        }

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:9000")
            //{
            //    Headers =
            //    {
            //        {HeaderNames.Accept, "application/json"},
            //        {HeaderNames.Authorization,""},
            //        {HeaderNames.ContentType,"application/json"}, 
            //    }
            //};
            HttpClient httpClient = _httpClientFactory.CreateClient("ApiGateway");
            var httpResponseMessage = await httpClient.GetAsync("/classroom/all");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //httpResponseMessage
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var classData = await JsonSerializer.DeserializeAsync<List<Classroom>>(contentStream);
                return View(classData);
            }

            //client.BaseAddress = new Uri("https://localhost:9000");
            //var respone = client.GetAsync("/classroom/all").Result;
            //// check authenticate
            //if (respone.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //{
            //    //unless client authenticated
            //    return RedirectToAction("Login", "Authenticate");
            //}
            //// if client authenticated
            //string jsonData = respone.Content.ReadAsStringAsync().Result;
            ////transf JSON data to Object data
            //var classData = Newtonsoft.Json.JsonConvert.DeserializeObject<Classroom>(jsonData);
            //var classData = await _classroomService.GetAllClassroom();
            return RedirectToAction("Login","Authenticate");
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