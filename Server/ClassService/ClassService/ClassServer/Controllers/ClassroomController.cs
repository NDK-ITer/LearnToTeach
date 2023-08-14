using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IUnitOfWork_ClassroomService _unitOfWork_ClassroomService;

        public ClassroomController(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            _unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult CreateClassroom([FromBody] ClassroomRequest ClassroomRequest)
        {
            try
            {
                var check = _unitOfWork_ClassroomService._classroomService.CreateClassroom(ClassroomRequest);
                if (check != 1) return BadRequest();
                return Ok("Created Classroom is successful!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult UpdateClassroom([FromBody] ClassroomRequest ClassroomRequest)
        {
            try
            {
                var check = _unitOfWork_ClassroomService._classroomService.UpdateClassroom(ClassroomRequest);
                if (check == 1) return Ok("Updated Classroom is successful!");
                else if (check == 0) return BadRequest("Something is Wrong!");
                else return BadRequest("Updated Classroom is fail!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult DeleteClassroom([FromRoute] string id)
        {
            try
            {
                var check = _unitOfWork_ClassroomService._classroomService.DeleteClassroom(id);
                if (check != 1) return BadRequest();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteMember/{idClassroom}/{idMember}")]
        public ActionResult DeleteMemberInClassroom([FromRoute] string idClassroom, string idMember)
        {
            try
            {
                var check = _unitOfWork_ClassroomService._classroomService.RemoveMember(idClassroom, idMember);
                if (check != 1) return BadRequest();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
