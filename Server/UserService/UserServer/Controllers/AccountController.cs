using Application.Requests;
using Application.Services;
using Events.UserServiceEvents;
using Infrastructure;
using JwtAuthenticationManager.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UserServer.Extensions;
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
        private readonly IOptions<ServerInfor> _serverInfor;
        private readonly IBus _bus;
        public AccountController(IUnitOfWork_UserService unitOfWork_UserService,
            UserEventMessage userEventMessage,
            IOptions<EndpointConfig> queue,
            IOptions<Address> address,
            IOptions<ServerInfor> serverInfor,
            IBus bus)
        {
            _unitOfWork_UserService = unitOfWork_UserService;
            _address = address;
            _serverInfor = serverInfor;
            _userEventMessage = userEventMessage;
            _queue = queue;
            _bus = bus;
        }
        
        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponses>? Login([FromBody] LoginRequest loginRequest)
        {
            var user = _unitOfWork_UserService.UserService.GetUserByEmail(loginRequest.Email);
            var jwt = _unitOfWork_UserService.UserService.LoginUser(loginRequest.Email, loginRequest.Password);
            if (jwt != null && user != null)
            {
                return jwt;
            }
            return StatusCode(204);
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                if (registerRequest.Password != registerRequest.PasswordIsConfirmed)
                {
                    return BadRequest("Password is not confirmed!");
                }
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
                        eventMessage = _userEventMessage.ConfirmEmail
                    });
                }

                return Ok($"Please check your email.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("confirm-email")]
        public async Task<ActionResult> ConfirmEmail(string email)
        {
            try
            {
                var user = _unitOfWork_UserService.UserService.GetUserByEmail(email);
                if (user == null) return BadRequest($"Not found user with {email}");
                if (user.IsVerified) return StatusCode(201,"Email had been confirmed");
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
                        eventMessage = _userEventMessage.ConfirmEmail
                    });
                }
                return Ok($"Please check your email.");
            }
            catch (Exception)
            {

                return BadRequest("Some thing wrong !");
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
        public async Task<IActionResult> ChangePassword(string idUser)
        {
            try
            {
                // Get user with idUser
                var user = _unitOfWork_UserService.UserService.GetUserById(idUser);
                if (user == null) return BadRequest();
                // Generate a OTP and store to Session with key value is "email"
                var otp = SecurityMethods.CreateRandomOTP();
                HttpContext.Session.SetString(user.PresentEmail, otp);
                // Send the OTP to Email
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueUserEvent>(new
                    {
                        id = Guid.Parse(user.id),
                        fullName = user.FirstName + " " + user.LastName,
                        email = user.PresentEmail,
                        content = $"Dear {user.FirstName + " " + user.LastName}!<br/><span style=\"color: #53A8F8;font-weight: bold;\">{otp}</span> is your OTP. This OTP is exist in {SessionInforConfig.SessionTimeOut} minutes. Don't share this OTP.",
                        subject = "OTP to change password your account",
                        eventMessage = _userEventMessage.ResetPassword
                    });
                }
                return Ok($"Have sent OTP to {user.PresentEmail}");
            }
            catch (Exception)
            {

                return BadRequest("Some thing wrong");
            }
        }

        [HttpPost]
        [Route("forget-password")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            try
            {
                // Get user with idUser
                var user = _unitOfWork_UserService.UserService.GetUserById(email);
                if (user == null) return BadRequest();
                // Generate a OTP and store to Session with key value is "email"
                var otp = SecurityMethods.CreateRandomOTP();
                if (string.IsNullOrEmpty(HttpContext.Session.GetString(user.PresentEmail)))
                {
                    HttpContext.Session.SetString(user.PresentEmail, otp);
                }
                // Send the OTP to Email
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueUserEvent>(new
                    {
                        id = Guid.Parse(user.id),
                        fullName = user.FirstName + " " + user.LastName,
                        email = user.PresentEmail,
                        content = $"Dear {user.FirstName + " " + user.LastName}!<br/><span style=\"color: #53A8F8;font-weight: bold;\">{otp}</span> is your OTP. This OTP is exist in {SessionInforConfig.SessionTimeOut} minutes. Don't share this OTP.",
                        subject = "OTP to change password your account",
                        eventMessage = _userEventMessage.ResetPassword
                    });
                }
                return Ok($"Have sent OTP to {user.PresentEmail}");
            }
            catch (Exception)
            {

                return BadRequest("Some thing wrong");
            }
        }

        [HttpPost]
        [Route("verify-otp")]
        public ActionResult VerifyOTP([FromBody]VerifyOTPModel verifyOTPModel)
        {
            try
            {
                var otp = HttpContext.Session.GetString(verifyOTPModel.email);
                if (otp != verifyOTPModel.OTP)
                {
                    return BadRequest("Incorrect OTP");
                }
                return Ok("correct OTP");
            }
            catch (Exception)
            {

                return BadRequest("Something was wrong!");
            }
        }
        
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

        [HttpPost]
        [Route("edit-infor")]
        public async Task<ActionResult> EditInformation([FromBody] EditInforRequest editInforRequest)
        {
            try
            {
                var check = _unitOfWork_UserService.UserService.UpdateUser(editInforRequest);
                if (!check)
                {
                    return BadRequest("Edit information is fail");
                }
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueUserEvent>(new
                    {
                        id = Guid.Parse(editInforRequest.IdUser),
                        fullName = editInforRequest.FirstName + " " + editInforRequest.LastName,
                        avatar = editInforRequest.Avatar,
                        eventMessage = _userEventMessage.Update
                    });
                }
                return Ok("Edit information is successful");
            }
            catch (Exception)
            {

                return BadRequest("Error! when edit information");
            }
        }
    }
}
