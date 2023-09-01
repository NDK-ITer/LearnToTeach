using Microsoft.AspNetCore.Mvc;
using ServiceComposition.Message;

namespace ServiceComposition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ClassroomConsumer messageConsumer;
        private readonly UserConsumer userConsumer;

        public TestController(ClassroomConsumer messageConsumer, UserConsumer userConsumer)
        {
            this.messageConsumer = messageConsumer;
            this.userConsumer = userConsumer;
        }

        [HttpGet]
        [Route("test")]
        public ActionResult<string> Get()
        {
            return "hi";   
        }
    }
}
