using ClassServer.FileMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DocumentFileMethod documentFile;
        public TestController(DocumentFileMethod documentFile)
        {
            this.documentFile = documentFile;
        }
        [HttpGet]
        [Route("")]
        public ActionResult Test1()
        {
            documentFile.DeleteFile("Documents", "ExerciseOTg0OTc3Nz.jpg");

            return Ok();
        }
    }
}
