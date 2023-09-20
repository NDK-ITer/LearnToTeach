using Application.Requests;
using Application.Services;
using JwtAuthenticationManager.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SendMail.Interfaces;
using UserServer.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork_UserService _unitOfWork_UserService;
        private readonly UserEventMessage _userEventMessage;
        private readonly IOptions<EndpointConfig> _queue;
        private readonly IBus _bus;
        public AccountController(IUnitOfWork_UserService unitOfWork_UserService,
            UserEventMessage userEventMessage,
            IOptions<EndpointConfig> queue,
            IBus bus)
        {
            _unitOfWork_UserService = unitOfWork_UserService;
            _userEventMessage = userEventMessage;
            _queue = queue;
            _bus = bus;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginReponse>? Login([FromBody] LoginRequest loginRequest)
        {
            var user = _unitOfWork_UserService.UserService.GetUserUsername(loginRequest.UserName);
            var jwt = _unitOfWork_UserService.UserService.GetJwtUserInfor(loginRequest.UserName, loginRequest.Password);
            if (jwt != null && user != null)
            {
                return jwt;
            }
            return StatusCode(204);
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                if (_unitOfWork_UserService.UserService.EmailIsExist(registerRequest.Email)) return BadRequest("Email was Exist.");
                if (_unitOfWork_UserService.UserService.UsernameIsExist(registerRequest.UserName)) return BadRequest("UserName was Exist.");
                //_sendEmail.SendEmailAsync(registerRequest.Email, "NDK", "ndk");
                var user = _unitOfWork_UserService.UserService.RegisterUser(registerRequest);
                if (user == null) return BadRequest("Register is false.");
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
