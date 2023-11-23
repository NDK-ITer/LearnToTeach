﻿using Application.Models;
using Application.Requests;
using Application.Services;
using ClassServer.Models;
using Events.ClassroomServiceEvents.Classroom;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ClassServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IUnitOfWork_ClassroomService _unitOfWork_ClassroomService;
        private readonly IOptions<EndpointConfig> _queue;
        private readonly IBus _bus;
        private readonly ClassroomEventMessage _classroomStateMessage;

        public ClassroomController(IUnitOfWork_ClassroomService unitOfWork_ClassroomService,
            ClassroomEventMessage classroomStateMessage,
            IOptions<EndpointConfig> queue,
            IBus bus)
        {
            _unitOfWork_ClassroomService = unitOfWork_ClassroomService;
            _classroomStateMessage = classroomStateMessage;
            _queue = queue;
            _bus = bus;
        }

        [HttpGet]
        [Route("public")]
        public ActionResult<List<ClassroomModel>> GetClassroomPublic()
        {
            try
            {
                var classroomResponse = _unitOfWork_ClassroomService._classroomService.GetAllClassroomPublic();
                if (classroomResponse.IsNullOrEmpty()) return NotFound();
                return classroomResponse;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route("id")]
        public ActionResult<ClassroomModel> GetClassById(string idClassroom)
        {
            try
            {
                var classroomResponse = _unitOfWork_ClassroomService._classroomService.GetClassroomById(idClassroom);
                if (classroomResponse != null)
                {
                    
                    return classroomResponse;
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route("name")]
        public ActionResult<ClassroomModel> GetClassByName( string nameClassroom)
        {
            try
            {
                var classroomResponse = _unitOfWork_ClassroomService._classroomService.GetClassroomByName(nameClassroom);
                if (classroomResponse != null)
                    return classroomResponse;
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateClassroom([FromBody] ClassroomRequest classroomRequest)
        {
            try
            {
                var check = _unitOfWork_ClassroomService._classroomService.CreateClassroom(classroomRequest);
                if (check == null) return BadRequest();
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null) 
                {
                    endPoint.Send<IGetValueClassroomEvent>(new
                    {
                        idClassroom = Guid.Parse(check.Id),
                        description = check.Description,
                        idUserHost = check.IdUserHost,
                        name = check.Name,
                        isPrivate = check.IsPrivate,
                        eventMessage = _classroomStateMessage.Create
                    });
                }
                return Ok("Created Classroom is successful!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut]
        [Route("update")]
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
        [Route("delete")]
        public ActionResult DeleteClassroom(string idClassroom)
        {
            try
            {
                var check = _unitOfWork_ClassroomService._classroomService.DeleteClassroom(idClassroom);
                if (check != 1) return BadRequest();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete]
        [Route("remove-member")]
        public ActionResult DeleteMemberInClassroom(string idClassroom, string idMember)
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