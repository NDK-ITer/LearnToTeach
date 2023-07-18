using Authentication_Application.Services;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork_Authenticate _unitOfWork_Authenticate;

        public AccountController(IUnitOfWork_Authenticate unitOfWork_Authenticate)
        {
            _unitOfWork_Authenticate = unitOfWork_Authenticate;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<LoginReponse>? Login([FromBody]LoginRequest loginRequest)
        {
            var jwt = _unitOfWork_Authenticate.AuthenticationService.GetJwtUserInfor(loginRequest.UserName, loginRequest.Password);
            return jwt;
        }
    }
}
