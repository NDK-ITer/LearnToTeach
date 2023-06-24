using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationUserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandle;

        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandle = jwtTokenHandler;
        }

        [HttpPost]
        public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            var authenticationResponse = _jwtTokenHandle.GenerateJwtToken(authenticationRequest);
            if (authenticationResponse == null) { return Unauthorized(); }
            return authenticationResponse;
        }
    }
}
