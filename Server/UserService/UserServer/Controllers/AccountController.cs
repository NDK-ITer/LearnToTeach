using Application.Requests;
using Application.Services;
using Events.UserServiceEvents;
using Infrastructure;
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
        private readonly IOptions<Address> _address;
        private readonly IBus _bus;
        public AccountController(IUnitOfWork_UserService unitOfWork_UserService,
            UserEventMessage userEventMessage,
            IOptions<EndpointConfig> queue,
            IOptions<Address> address,
            IBus bus)
        {
            _unitOfWork_UserService = unitOfWork_UserService;
            _address = address;
            _userEventMessage = userEventMessage;
            _queue = queue;
            _bus = bus;
        }
        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns>LoginResponses</returns>
        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponses>? Login([FromBody] LoginRequest loginRequest)
        {
            var user = _unitOfWork_UserService.UserService.GetUserUsername(loginRequest.UserName);
            var jwt = _unitOfWork_UserService.UserService.LoginUser(loginRequest.UserName, loginRequest.Password);
            if (jwt != null && user != null)
            {
                return jwt;
            }
            return StatusCode(204);
        }
        /// <summary>
        /// User Register
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns>StatusCode</returns>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                if (_unitOfWork_UserService.UserService.EmailIsExist(registerRequest.Email)) return BadRequest("Email was Exist.");
                if (_unitOfWork_UserService.UserService.UsernameIsExist(registerRequest.UserName)) return BadRequest("Username was Exist.");
                if (!PhoneNumberMethod.IsPhoneNumber(registerRequest.PhoneNumber)) return BadRequest("invalid phone number.");
                var user = _unitOfWork_UserService.UserService.RegisterUser(registerRequest);
                if (user == null) return BadRequest("Register is false.");

                //Get user token
                var userToken = user.TokenAccess;
                //create URL to verify
                var urlVerify = $"{_address.Value.UserAddress}/api/Account/verify-account/?idUser={user.id}&token={userToken}";
                //Publish a event to Saga orchestration
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
                var user = _unitOfWork_UserService.UserService.ConfirmEmailUser(idUser,token);
                if (user == null) return BadRequest();
                var url = string.Empty;
                return Ok("Verify is Successful");
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody]string? idUser)
        {
            try
            {
                // Get user with idUser
                var user = _unitOfWork_UserService.UserService.GetUserById(idUser);
                if (user == null) return BadRequest();
                var email = user.PresentEmail;
                // Generate a OTP and store to Session with key value is "email"
                var otp = SecurityMethods.CreateRandomOTP();
                // Send the OTP to Email
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueUserEvent>(new
                    {
                        id = Guid.Parse(user.id),
                        fullName = user.FirstName + " " + user.LastName,
                        email = user.PresentEmail,
                        content = $"{otp} is your OTP. <br/>This OTP is exist in 60s. <br/>Don't share this OTP.",
                        subject = "OTP to change password your account",
                        eventMessage = _userEventMessage.ResetPassword
                    });
                }
                return Ok($"Have sent OTP to {email}");
            }
            catch (Exception)
            {

                return BadRequest("Some thing wrong");
            }
        }
        [HttpPost]
        [Route("")]
        public ActionResult VerifyOTP(string otp)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Something was wrong!");
            }
        }
        /// <summary>
        /// "ForgotPassword" and "ChangePassword" will use this Action.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("reset-password")]
        public ActionResult ResetPassword([FromBody] ResetPasswordModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.NewPassword!=model.ConfirmPassword) return BadRequest("Password isn't confirmed");
                    
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Some thing wrong");
            }
        }

    }
}
