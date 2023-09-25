using Application.Requests;
using Application.Services;
using Events.UserServiceEvents;
using JwtAuthenticationManager.Models;
using MassTransit;
using MassTransit.Internals.GraphValidation;
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
        private readonly IOptions<ApiGatewayAddress> _apigatewayAddress;
        private readonly IBus _bus;
        public AccountController(IUnitOfWork_UserService unitOfWork_UserService,
            UserEventMessage userEventMessage,
            IOptions<EndpointConfig> queue,
            IOptions<ApiGatewayAddress> apigatewayAddress,
            IBus bus)
        {
            _unitOfWork_UserService = unitOfWork_UserService;
            _apigatewayAddress = apigatewayAddress;
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
        public async Task<ActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                if (_unitOfWork_UserService.UserService.EmailIsExist(registerRequest.Email)) return BadRequest("Email was Exist.");
                if (_unitOfWork_UserService.UserService.UsernameIsExist(registerRequest.UserName)) return BadRequest("UserName was Exist.");
                var user = _unitOfWork_UserService.UserService.RegisterUser(registerRequest);
                if (user == null) return BadRequest("Register is false.");


                var userToken = user.TokenAccess;
                var urlVerify = $"{_apigatewayAddress.Value.UserAddress}/api/Account/verify-account/?idUser={user.id}&token={userToken}";

                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueUserEvent>(new
                    {
                        id = Guid.Parse(user.id),
                        fullName = user.FirstName + " " + user.LastName,
                        email = user.PresentEmail,
                        content = $"<a href='{urlVerify}'>Click here</a> to verify your account",
                        subject = "Confirm your account",
                        eventMessage = _userEventMessage.ConfirmAccount
                    });
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("verify-account")]
        public ActionResult<string> VerifyAccount(string idUser, string token)
        {
            try
            {
                var user = _unitOfWork_UserService.UserService.VerifyUserById(idUser,token);
                if (user == null) return BadRequest();
                var url = string.Empty;
                return Ok("Verify is Successful");
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
        }

    }
}
