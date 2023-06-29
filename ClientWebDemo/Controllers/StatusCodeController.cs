using Microsoft.AspNetCore.Mvc;

namespace ClienWebDemo.Controllers
{
    public class StatusCodeController : Controller
    {
        public IActionResult ErrorNotFound()
        {
            return View();
        }
    }
}
