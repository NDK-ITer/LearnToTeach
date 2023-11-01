using Application.Models;
using Application.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace UserServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork_UserService _unitOfWork_UserService;
        private readonly IPublishEndpoint _publishEndpoint;
        public UserController(IUnitOfWork_UserService unitOfWork_UserService,
            IPublishEndpoint publishEndpoint)
        {
            _unitOfWork_UserService = unitOfWork_UserService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        [Route("get-all")]
        public ActionResult<List<UserModel>> GetAllUser()
        {
            try
            {
                var listUser = _unitOfWork_UserService.UserService.GetAllUsers();
                if (listUser == null) { return NotFound("User is empty"); }
                var listUserModel = new List<UserModel>();
                foreach (var item in listUser)
                {
                    listUserModel.Add(new UserModel(item));
                }
                return listUserModel;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public ActionResult<UserModel> GetUserById([FromRoute] string? idUser)
        {
            try
            {
                if (idUser == null) return BadRequest("idUser is null");
                var result = _unitOfWork_UserService.UserService.GetUserById(idUser);
                if (result == null) return NotFound();
                return new UserModel(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("role")]
        public ActionResult<List<UserModel>> GetUserWithRole([FromRoute]string roleName) 
        {
            try
            {
                if (roleName == null) return BadRequest("roleName is null");
                var result = _unitOfWork_UserService.UserService.GetUserWithRole(roleName);
                if (result == null) return NotFound();
                var listUserModel = new List<UserModel>();
                foreach (var item in result)
                {
                    listUserModel.Add(new UserModel(item));
                }
                return listUserModel;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
