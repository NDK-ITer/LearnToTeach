using Microsoft.AspNetCore.Mvc;
using ServiceComposition.Message;

namespace ServiceComposition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MessageConsumer messageConsumer;

        public TestController(MessageConsumer messageConsumer)
        {
            this.messageConsumer = messageConsumer;
        }

        [HttpGet]
        [Route("test")]
        public ActionResult<string> Get()
        {
            return "hi";   
        }
    }
}
