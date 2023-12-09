using Application.Models;
using Application.Requests;
using Application.Services;
using Events.UserServiceEvents;
using FileStoreServer.FileMethods;
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
        private readonly ImageMethod _imageMethod;
        private readonly IBus _bus;
        public AccountController(IUnitOfWork_UserService unitOfWork_UserService,
            UserEventMessage userEventMessage,
            IOptions<EndpointConfig> queue,
            IOptions<Address> address,
            IOptions<ServerInfor> serverInfor,
            ImageMethod imageMethod,
            IBus bus)
        {
            _unitOfWork_UserService = unitOfWork_UserService;
            _address = address;
            _imageMethod = imageMethod;
            _serverInfor = serverInfor;
            _userEventMessage = userEventMessage;
            _queue = queue;
            _bus = bus;
        }

        [HttpPost]
        [HttpOptions]
        [Route("login")]
        public ActionResult<LoginResponses>? Login([FromForm] LoginRequest loginRequest)
        {
            try
            {
                var resultstatus = new ResultStatus()
                {
                    status = -3,
                    message = ""
                };

                var user = _unitOfWork_UserService.UserService.GetUserByEmail(loginRequest.Email);
                if (user == null)
                {
                    resultstatus.status = -2;
                    resultstatus.message = "account not found";
                    return Ok(resultstatus);
                }
                var jwt = _unitOfWork_UserService.UserService.LoginUser(loginRequest.Email, loginRequest.Password);               
                 if (jwt == null)
                {
                    resultstatus.status = -1;
                    resultstatus.message = "password incorrect";
                }
                else if (user != null && jwt != null)
                {
                    return jwt;
                }
                return Ok(resultstatus);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("user-data")]
        public ActionResult<UserModel> GetUserById([FromForm] string? idUser)
        {
            var resultStatus = new ResultStatus()
            {
                status = -1,
                message = "Error!"
            };
            try
            {
                if (idUser == null)
                {
                    resultStatus.status = 0;
                    resultStatus.message = "idUser is null";
                    return Ok(resultStatus);
                }
                var result = _unitOfWork_UserService.UserService.GetUserById(idUser);
                if (result == null) return NotFound();
                return new UserModel(result);
            }
            catch (Exception e)
            {
                resultStatus.message = e.Message;
                return BadRequest(resultStatus);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("register")]
        public async Task<ActionResult> Register([FromForm] RegisterRequest registerRequest)
        {
            try
            {
                var resultstatus = new ResultStatus()
                {
                    status = -5,
                    message = ""
                };
                if (registerRequest.Password != registerRequest.PasswordIsConfirmed)
                {
                    resultstatus.status = -4;
                    resultstatus.message = "Password is not confirmed!";
                    return Ok(resultstatus);
                }
                if (_unitOfWork_UserService.UserService.EmailIsExist(registerRequest.Email))
                {
                    resultstatus.status = -3;
                    resultstatus.message = "Email was Exist.";
                    return Ok(resultstatus);
                }
                if (!PhoneNumberMethod.IsPhoneNumber(registerRequest.PhoneNumber))
                {
                    resultstatus.status = -2;
                    resultstatus.message = "invalid phone number.";
                    return Ok(resultstatus);
                }
                if (_unitOfWork_UserService.UserService.PhoneNumberIsExist(registerRequest.PhoneNumber))
                {
                    resultstatus.status = -6;
                    resultstatus.message = "phone number was exist";
                    return Ok(resultstatus);
                }
                var user = _unitOfWork_UserService.UserService.RegisterUser(registerRequest);
                if (user == null)
                {
                    resultstatus.status = -1;
                    resultstatus.message = "Register is false.";
                    return Ok(resultstatus);
                }
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
                        avatar = _imageMethod.GenerateToString(registerRequest.Avatar),
                        serverName = _serverInfor.Value.Name,
                        subject = "Confirm your account",
                        eventMessage = _userEventMessage.Create
                    });
                }
                resultstatus.status = 1;
                resultstatus.message = "Register Success Please check your email.";
                return Ok(resultstatus);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [HttpOptions]
        [Route("confirm-email")]
        public async Task<ActionResult> ConfirmEmail(string email)
        {
            try
            {
                var resultstatus = new ResultStatus()
                {
                    status = -1,
                    message = string.Empty
                };
                var user = _unitOfWork_UserService.UserService.GetUserByEmail(email);
                if (user == null)
                {
                    resultstatus.message = $"Not found user with {email}";
                    return BadRequest(resultstatus);
                }
                if (user.IsVerified) return StatusCode(201, "Email had been confirmed");
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
                    resultstatus.status = 1;
                    resultstatus.message = $"Please check your email.";
                }
                return Ok(resultstatus);
            }
            catch (Exception)
            {

                return BadRequest("Some thing wrong !");
            }
        }

        [HttpGet]
        [HttpOptions]
        [Route("verify-account")]
        public ActionResult<string> VerifyAccount(string idUser, string token)
        {
            try
            {
                var user = _unitOfWork_UserService.UserService.ConfirmEmailUser(idUser, token);
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
        [HttpOptions]
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
        [HttpOptions]
        [Route("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromForm] string Email)
        {
            try
            {
                var resultstatus = new ResultStatus()
                {
                    status = -3,
                    message = ""
                };
                // Get user
                var user = _unitOfWork_UserService.UserService.GetUserByEmail(Email);
                if (user == null)
                {
                    resultstatus.status = -1;
                    resultstatus.message = "email not found";
                    return Ok(resultstatus);
                };
                // get a OTP and store to me MemoryCache with key value is "email"
                var otp = _unitOfWork_UserService.UserService.GetOtp(Email);              
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
                resultstatus.status = 1;
                resultstatus.message = $"Have sent OTP to {user.PresentEmail}";
                return Ok(resultstatus);
            }
            catch (Exception)
            {

                return BadRequest("Some thing wrong");
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("verify-otp")]
        public ActionResult VerifyOTP([FromForm] VerifyOTPModel verifyOTPModel)
        {
            try
            {
                var resultstatus = new ResultStatus()
                {
                    status = -3,
                    message = ""
                };
                // get a OTP and store to me MemoryCache with key value is "email"
                var otp = _unitOfWork_UserService.UserService.verifyOTP(verifyOTPModel.Email);
                if (otp != verifyOTPModel.OTP)
                {
                    resultstatus.status = -1;
                    resultstatus.message = "Incorrect OTP";
                    return Ok(resultstatus);
                }
                resultstatus.status = 1;
                resultstatus.message = "Correct OTP";
                return Ok(resultstatus);
            }
            catch (Exception)
            {

                return BadRequest("Something was wrong!");
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("reset-password")]
        public ActionResult ResetPassword([FromForm] ResetPasswordModel model)
        {
            try
            {
                var resultstatus = new ResultStatus()
                {
                    status = -4,
                    message = ""
                };
                if (model.NewPassword != model.ConfirmPassword)
                {
                    resultstatus.status = -3;
                    resultstatus.message = "Password is not confirmed!";
                    return Ok(resultstatus);
                }
                var user = _unitOfWork_UserService.UserService.GetUserByEmail(model.Email);
                if (user == null)
                {
                    resultstatus.status = -2;
                    resultstatus.message = "User not found!";
                    return Ok(resultstatus);
                }
                var reset = _unitOfWork_UserService.UserService.ResetPasswordUser(model.Email, model.NewPassword);
                if (reset == null)
                {
                    resultstatus.status = -1;
                    resultstatus.message = "not reset password";
                    return Ok(resultstatus);
                }
                resultstatus.status = 1;
                resultstatus.message = "password was updated";               
                return Ok(resultstatus);
            }
            catch (Exception)
            {
                return BadRequest("Some thing wrong");
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("edit-infor")]
        public async Task<ActionResult> EditInformation([FromForm] EditInforRequest editInforRequest)
        {
            try
            {
                var resultstatus = new ResultStatus()
                {
                    status = -4,
                    message = ""
                };

                var updateUserModel = new UpdateUserModel()
                {
                    IdUser = editInforRequest.IdUser,
                    FirstName = editInforRequest.FirstName,
                    LastName = editInforRequest.LastName,
                };
                var check = _unitOfWork_UserService.UserService.UpdateUser(updateUserModel);
                if (!check)
                {
                     resultstatus.status = -1;
                    resultstatus.message = "Edit information is fail";
                    return Ok(resultstatus);
                }
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueUserEvent>(new
                    {
                        id = Guid.Parse(editInforRequest.IdUser),
                        fullName = editInforRequest.FirstName + " " + editInforRequest.LastName,
                        avatar = _imageMethod.GenerateToString(editInforRequest.Avatar),
                        email = editInforRequest.Email,
                        eventMessage = _userEventMessage.Update,
                        serverName = _serverInfor.Value.Name
                    });
                }
                resultstatus.status = 1;
                resultstatus.message = "Edit information is successful";
                return Ok(resultstatus);
            }
            catch (Exception)
            {

                return BadRequest("Error! when edit information");
            }
        }
    }
}
