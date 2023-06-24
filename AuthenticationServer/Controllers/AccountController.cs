﻿using JwtAuthenticationManager;
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

        [HttpPost]
        public ActionResult<AuthenticationReponse?> Authenticate([FromBody]AuthenticationRequest authenticationRequest)
        {
            var authenticationReponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
            if (authenticationReponse == null) { return Unauthorized(); }
            return authenticationReponse;
        }
    }
}
