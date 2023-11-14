﻿using Application.Models;
using Application.Requests;
using Application.Services;
using ClassServer.Models;
using Events.ClassroomServiceEvents.Classroom;
using Events.ClassroomServiceEvents.Member;
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
        private readonly IOptions<ServerInfor> _serverInfor;
        private readonly IBus _bus;
        private readonly ClassroomEventMessage _classroomStateMessage;

        public ClassroomController(IUnitOfWork_ClassroomService unitOfWork_ClassroomService,
            ClassroomEventMessage classroomStateMessage,
            IOptions<EndpointConfig> queue,
            IOptions<ServerInfor> serverInfor,
            IBus bus)
        {
            _unitOfWork_ClassroomService = unitOfWork_ClassroomService;
            _classroomStateMessage = classroomStateMessage;
            _serverInfor = serverInfor;
            _queue = queue;
            _bus = bus;
        }

        [HttpGet]
        [Route("public")]
        public ActionResult<List<ClassroomModel>> GetClassroomPublic()
        {
            try
            {
                var classroom = _unitOfWork_ClassroomService._classroomService.GetAllClassroomPublic();
                var classroomResponse = new List<ClassroomModel>();
                foreach (var item in classroom)
                {
                    classroomResponse.Add(new ClassroomModel(item));
                }
                if (classroomResponse.IsNullOrEmpty()) return NotFound();
                return classroomResponse;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ClassroomModel> GetClassById(string idClassroom)
        {
            try
            {
                var classroomResponse = _unitOfWork_ClassroomService._classroomService.GetClassroomById(idClassroom);
                if (classroomResponse != null)
                {
                    return new ClassroomModel(classroomResponse);
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
        public ActionResult<ClassroomModel> GetClassByName(string nameClassroom)
        {
            try
            {
                var classroom = _unitOfWork_ClassroomService._classroomService.GetClassroomByName(nameClassroom);
                if (classroom != null)
                {
                    var classroomResponse = new ClassroomModel(classroom);
                    return classroomResponse;
                }
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
        public async Task<ActionResult> UpdateClassroom([FromBody] ClassroomRequest ClassroomRequest)
        {
            try
            {
                var check = _unitOfWork_ClassroomService._classroomService.UpdateClassroom(ClassroomRequest);
                if (check == 1)
                {
                    var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                    if (endPoint != null)
                    {
                        endPoint.Send<IGetValueClassroomEvent>(new
                        {
                            idClassroom = Guid.Parse(ClassroomRequest.idClassroom),
                            description = ClassroomRequest.description,
                            idUserHost = string.Empty,
                            name = ClassroomRequest.name,
                            isPrivate = ClassroomRequest.isPrivate,
                            eventMessage = _classroomStateMessage.Update
                        });
                    }
                    return Ok("Updated Classroom is successful!");
                }
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
        public async Task<ActionResult> DeleteClassroom(string idClassroom)
        {
            try
            {
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueClassroomEvent>(new
                    {
                        idClassroom = Guid.Parse(idClassroom),
                        description = string.Empty,
                        idUserHost = string.Empty,
                        name = string.Empty,
                        isPrivate = false,
                        eventMessage = _classroomStateMessage.Delete,
                    });
                }
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

        [HttpPost]
        [Route("add-member")]
        public async Task<ActionResult> AddMemberToClassroom([FromBody] MemberRequest memberRequest)
        {
            try
            {
                if (memberRequest == null) return BadRequest("Request was null!");
                if (memberRequest.listIdMember.IsNullOrEmpty()) return BadRequest("listMember was empty or null");
                var classroom = _unitOfWork_ClassroomService._classroomService.GetClassroomById(memberRequest.idClassroom);
                if (classroom == null) return BadRequest("Classroom is not exist!");
                var listCheckFalse = new Dictionary<string,bool>();
                foreach (var item in memberRequest.listIdMember)
                {
                    var check = _unitOfWork_ClassroomService._memberService.AddMember(new MemberModel
                    {
                        idMember = item,
                        avatar = "",
                        nameMember = "",
                        role = "member".ToUpper(),
                        description = ""
                    }, memberRequest.idClassroom);
                    if (check == 1)
                    {
                        var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                        if (endPoint != null)
                        {
                            endPoint.Send<IGetValueMemberEvent>(new
                            {
                                IdClassroom = Guid.Parse(memberRequest.idClassroom),
                                IdMember = item,
                                eventMessage = _classroomStateMessage.Create,
                                NameMember = string.Empty,
                                Avatar = string.Empty,
                                NameClassroom = classroom.Name
                            });
                        }
                    }
                    else
                    {
                        listCheckFalse.Add(item,false);
                    }
                }
                if (!listCheckFalse.IsNullOrEmpty())
                {
                    return BadRequest($"have {listCheckFalse.Count} false");
                }
                return Ok("Add member successful, please wait a minute");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
