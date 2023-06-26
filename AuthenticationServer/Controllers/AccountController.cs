using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult<AuthenticationReponse?> Login([FromBody]AuthenticationRequest authenticationRequest)
        {
            var authenticationReponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
            if (authenticationReponse == null) { return Unauthorized(); }
            return authenticationReponse;
        }
    }
}
