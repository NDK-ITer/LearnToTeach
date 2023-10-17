using Application.Models;
using Application.Services;
using ClassServer.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ClassServer.Controllers
{
    [Route("api/manager-classroom")]
    [ApiController]
    public class ManagerClassroomController : ControllerBase
    {
        private readonly IUnitOfWork_ClassroomService _unitOfWork_ClassroomService;
        public ManagerClassroomController(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            _unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<ClassroomModel>> GetAllClassroom()
        {
            try
            {
                var classroomResponse = _unitOfWork_ClassroomService._classroomService.GetAllClassroom();
                if (classroomResponse.IsNullOrEmpty()) return NotFound();
                return classroomResponse;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
