using Application.Models;
using Application.Requests;
using Application.Services;
using ClassServer.FileMethods;
using ClassServer.Models;
using Events.ClassroomServiceEvents.Classroom;
using Events.ClassroomServiceEvents.Member;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using XAct.Messages;

namespace ClassServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IUnitOfWork_ClassroomService _unitOfWork_ClassroomService;
        private readonly IOptions<EndpointConfig> _queue;
        private readonly ImageMethod _imageMethod;
        private readonly IBus _bus;
        private readonly ClassroomEventMessage _classroomStateMessage;

        public ClassroomController(IUnitOfWork_ClassroomService unitOfWork_ClassroomService,
            ClassroomEventMessage classroomStateMessage,
            IOptions<EndpointConfig> queue,
            ImageMethod imageMethod,
            IBus bus)
        {
            _unitOfWork_ClassroomService = unitOfWork_ClassroomService;
            _classroomStateMessage = classroomStateMessage;
            _imageMethod = imageMethod;
            _queue = queue;
            _bus = bus;
        }

        [HttpGet]
        [HttpOptions]
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
        [HttpOptions]
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
        [HttpOptions]
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
        [HttpOptions]
        [Route("create")]
        public async Task<IActionResult> CreateClassroom([FromForm] ClassroomRequest classroomRequest)
        {
            var resultMessage = new ResultStatus()
            {
                Status = 0,
                Message = string.Empty
            };
            try
            {
                if (classroomRequest.idUserHost.IsNullOrEmpty())
                {
                    resultMessage.Message = "\"idUserHost\" is null or empty";
                    return Ok(resultMessage);
                }
                
                var addClassroomModel = new AddClassroomModel()
                {
                    idClassroom = classroomRequest.idClassroom,
                    idUserHost = classroomRequest.idUserHost,
                    description = classroomRequest.description,
                    name = classroomRequest.name,
                    isPrivate = classroomRequest.isPrivate,
                };
                var check = _unitOfWork_ClassroomService._classroomService.CreateClassroom(addClassroomModel);
                if (check == null) return BadRequest();
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueClassroomEvent>(new
                    {
                        idMessage = Guid.NewGuid(),
                        idClassroom = check.Id,
                        description = check.Description,
                        idUserHost = classroomRequest.idUserHost,
                        name = check.Name,
                        avatar = _imageMethod.GenerateToString(classroomRequest.Avatar),
                        isPrivate = check.IsPrivate,
                        eventMessage = _classroomStateMessage.Create
                    });
                }
                resultMessage.Status = 1;
                resultMessage.Message = "Created Classroom is successful!";
                return Ok(resultMessage);
            }
            catch (Exception e)
            {
                resultMessage.Status = -1;
                resultMessage.Message = e.Message;
                return BadRequest(resultMessage);
            }
        }

        [HttpPut]
        [HttpOptions]
        [Route("update")]
        public async Task<ActionResult> UpdateClassroom([FromForm] ClassroomRequest classroomRequest)
        {
            try
            {
                
                var check = _unitOfWork_ClassroomService._classroomService.UpdateClassroom(classroomRequest);
                if (check == 1)
                {
                    var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                    if (endPoint != null)
                    {
                        endPoint.Send<IGetValueClassroomEvent>(new
                        {
                            idClassroom = Guid.Parse(classroomRequest.idClassroom),
                            description = classroomRequest.description,
                            idUserHost = string.Empty,
                            name = classroomRequest.name,
                            isPrivate = classroomRequest.isPrivate,
                            avatar = _imageMethod.GenerateToString(classroomRequest.Avatar),
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
        [HttpOptions]
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
        [HttpOptions]
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
        [HttpOptions]
        [Route("join-classroom/{idClassroom}/{idMember}")]
        public async Task<ActionResult> JoinClassroom([FromRoute] string idClassroom, [FromRoute] string idMember)
        {
            var result = new ResultStatus()
            {
                Status = -1,
                Message = string.Empty
            };
            try
            {
                var classroom = _unitOfWork_ClassroomService._classroomService.GetClassroomById(idClassroom);
                if (classroom != null)
                {
                    var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                    if (endPoint != null)
                    {
                        endPoint.Send<IGetValueMemberEvent>(new
                        {
                            IdMessage = Guid.NewGuid(),
                            IdClassroom = idClassroom,
                            IdMember = idMember,
                            eventMessage = _classroomStateMessage.Create,
                            NameMember = string.Empty,
                            Avatar = string.Empty,
                            NameClassroom = classroom.Name
                        });
                    }
                    result.Status = 1;
                    result.Message = $"join classroom \"{classroom.Name}\" is successful";
                    return Ok(result);
                }
                result.Status = 0;
                result.Message = $"classroom with id \"{idClassroom}\" is not exist";
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                return BadRequest(result);
            }
        }
    }
}
