using Authentication_Application.Requests;
using Authentication_Application.Services;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendMail.Interfaces;

namespace Authentication_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork_UserService _unitOfWork_UserService;
        private readonly IEmailSender _sendEmail;

        public AccountController(IUnitOfWork_UserService unitOfWork_UserService, IEmailSender sendEmail)
        {
            _unitOfWork_UserService = unitOfWork_UserService;
            _sendEmail = sendEmail;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginReponse>? Login([FromBody]LoginRequest loginRequest)
        {
            var jwt = _unitOfWork_UserService.AuthenticationService.GetJwtUserInfor(loginRequest.UserName, loginRequest.Password);
            if (jwt != null)
            {
                return jwt;
            }
            return StatusCode(204);
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register([FromBody]RegisterRequest registerRequest)
        {
            try
            {
                _sendEmail.SendEmailAsync(registerRequest.Email,"NDK","ndk");
                _unitOfWork_UserService.UserService.RegisterUser(registerRequest);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("GetDateTime")]
        public ActionResult<DateTime>? GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
