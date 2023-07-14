using Authentication_Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork_Authenticate _authenticate;
        public TestController(IUnitOfWork_Authenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult Get()
        {
            var test = _authenticate.User.GetAll();
            return Ok(test);
        }
    }
}
