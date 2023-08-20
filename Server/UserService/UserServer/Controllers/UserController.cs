﻿using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace UserServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork_UserService _unitOfWork_UserService;
        public UserController(IUnitOfWork_UserService unitOfWork_UserService)
        {
            _unitOfWork_UserService = unitOfWork_UserService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<UserModel>> GetAllUser()
        {
            try
            {
                var listUser = _unitOfWork_UserService.UserService.GetAllUsers();
                if (listUser == null) { return NotFound("User is empty"); }
                return listUser;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{idUser}")]
        public ActionResult<UserModel> GetUserById([FromRoute] string? idUser)
        {
            try
            {
                if (idUser == null) return BadRequest("idUser is null");
                var result = _unitOfWork_UserService.UserService.GetUserById(idUser);
                return result;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
