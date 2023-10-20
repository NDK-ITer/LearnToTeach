using Microsoft.AspNetCore.Mvc;

namespace ClienWebDemo.Controllers
{
    public class StatusCodeErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult Forbidden()
        {
            return View();
        }

        public IActionResult Unauthorized()
        {
            return RedirectToAction("Login", "Authenticate");
        }
    }
}
