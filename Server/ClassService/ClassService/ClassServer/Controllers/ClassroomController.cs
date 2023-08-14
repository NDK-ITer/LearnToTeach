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
        public ActionResult CreateClassroom([FromBody] CreateClassroomRequest createClassroomRequest)
        {
            try
            {
                var result = _unitOfWork_ClassroomService._classroomService.CreateClassroom(createClassroomRequest);
                return Ok("Created Classroom is successful!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult UpdateClassroom([FromBody] UpdateClassroomRequest updateClassroomRepuest)
        {
            try
            {
                var check = _unitOfWork_ClassroomService._classroomService.UpdateClassroom(updateClassroomRepuest);
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
                _unitOfWork_ClassroomService._classroomService.DeleteClassroom(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("AddMember")]
        public ActionResult AddMember([FromBody] MemberClassroomRequest memberClassroomRequest)
        {
            try
            {
                _unitOfWork_ClassroomService._classroomService.AddMember(memberClassroomRequest.idClassroom, memberClassroomRequest);
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
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
