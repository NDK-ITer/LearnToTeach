using Application.Requests;
using Application.Services;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;
using SendMail.Interfaces;

namespace Server.Controllers
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
                if (_unitOfWork_UserService.UserService.EmailIsExist(registerRequest.Email)) return BadRequest("Email was Exist.");
                //_sendEmail.SendEmailAsync(registerRequest.Email, "NDK", "ndk");
                var addUser = _unitOfWork_UserService.UserService.RegisterUser(registerRequest);
                if (addUser == false) return BadRequest("Register is false.");
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
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
