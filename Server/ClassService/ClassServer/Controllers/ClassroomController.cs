using Application.Models.ModelsOfClassroom;
using Application.Requests.Classroom;
using Application.Requests.Exercise;
using Application.Services;
using ClassServer.FileMethods;
using ClassServer.Models;
using Events.ClassroomServiceEvents.Classroom;
using Events.ClassroomServiceEvents.Member;
using Infrastructure;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using XAct.Messages;
using static MassTransit.ValidationResultExtensions;

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
            var result = new ResultStatus()
            {
                Status = 0,
                Message = string.Empty
            };
            try
            {
                var classroomResponse = _unitOfWork_ClassroomService._classroomService.GetClassroomById(idClassroom);
                if (classroomResponse != null)
                {
                    return new ClassroomModel(classroomResponse);
                }
                result.Message = $"classroom \"{idClassroom}\" is not exist";
                return Ok(result);
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
        public async Task<ActionResult> CreateClassroom([FromForm] ClassroomRequest classroomRequest)
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
                    key = classroomRequest.key,
                };
                var check = _unitOfWork_ClassroomService._classroomService.CreateClassroom(addClassroomModel);
                if (check == null)
                {
                    resultMessage.Message = "add classroom is false";
                    return Ok(resultMessage);
                }
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
                resultMessage.Message = $"Created Classroom\"{check.Id}\" is successful!";
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
            var result = new ResultStatus()
            {
                Status = -1,
                Message = "Error!"
            };
            try
            {

                var checkHost = _unitOfWork_ClassroomService._memberService.IsHost(classroomRequest.idMember, classroomRequest.idClassroom);
                if (!checkHost.Item1)
                {
                    result.Status = 0;
                    result.Message = checkHost.Item2;
                    return Ok(result);
                }
                var check = _unitOfWork_ClassroomService._classroomService.UpdateClassroom(classroomRequest);
                if (check == 1)
                {
                    var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                    if (endPoint != null)
                    {
                        endPoint.Send<IGetValueClassroomEvent>(new
                        {
                            idMessage = Guid.NewGuid(),
                            idClassroom = classroomRequest.idClassroom,
                            description = classroomRequest.description,
                            idUserHost = string.Empty,
                            name = classroomRequest.name,
                            isPrivate = classroomRequest.isPrivate,
                            avatar = _imageMethod.GenerateToString(classroomRequest.Avatar),
                            eventMessage = _classroomStateMessage.Update
                        });
                    }
                    result.Status = 1;
                    result.Message = "Update successful";
                    return Ok(result);
                }
                else
                {
                    result.Status = 0;
                    result.Message = "Update fail";
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [HttpOptions]
        [Route("delete")]
        public async Task<ActionResult> DeleteClassroom(string? idClassroom)
        {
            try
            {
                var resultMessage = new ResultStatus()
                {
                    Status = 0,
                    Message = string.Empty
                };
                var endPoint = await _bus.GetSendEndpoint(new Uri("queue:" + _queue.Value.SagaBusQueue));
                if (endPoint != null)
                {
                    endPoint.Send<IGetValueClassroomEvent>(new
                    {
                        idMessage = Guid.NewGuid(),
                        idClassroom = idClassroom,
                        description = string.Empty,
                        idUserHost = string.Empty,
                        name = string.Empty,
                        isPrivate = false,
                        eventMessage = _classroomStateMessage.Delete,
                    });
                    resultMessage.Status = 1;
                    resultMessage.Message = "deleted classroom successfull";
                    return Ok(resultMessage);
                }
                resultMessage.Status = 0;
                resultMessage.Message = "deleted classroom fail";
                return Ok(resultMessage);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //fix
        [HttpDelete]
        [HttpOptions]
        [Route("remove-member")]
        public async Task<ActionResult> DeleteMemberInClassroom(string idClassroom, string idMember, string idHostMember)
        {
            try
            {
                var resultMessage = new ResultStatus()
                {
                    Status = 0,
                    Message = string.Empty
                };
                var checkHost = _unitOfWork_ClassroomService._memberService.IsHost(idHostMember, idClassroom);
                if (!checkHost.Item1)
                {
                    resultMessage.Status = 0;
                    resultMessage.Message = checkHost.Item2;
                    return Ok(resultMessage);
                }
                var check = _unitOfWork_ClassroomService._classroomService.RemoveMember(idClassroom, idMember);
                if (check == 1)
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
                                eventMessage = _classroomStateMessage.Delete,
                                NameMember = string.Empty,
                                Avatar = string.Empty,
                                NameClassroom = classroom.Name
                            });
                        }
                        resultMessage.Status = 1;
                        resultMessage.Message = $"Leave classroom \"{classroom.Name}\" is successful";
                        return Ok(resultMessage);
                    }
                    resultMessage.Status = 1;
                    resultMessage.Message = "deleted classroom Member successful";
                    return Ok(resultMessage);
                };
                resultMessage.Message = "deleted classroom Member fail";
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [HttpOptions]
        [Route("join-classroom")]
        public async Task<ActionResult> JoinClassroom([FromForm] string? idClassroom, [FromForm] string? idMember, [FromForm] string? key)
        {
            var result = new ResultStatus()
            {
                Status = -1,
                Message = "Error!"
            };
            try
            {
                var classroom = _unitOfWork_ClassroomService._classroomService.GetClassroomById(idClassroom);
                if (classroom == null)
                {
                    result.Status = 0;
                    result.Message = $"classroom with id \"{idClassroom}\" is not exist";
                    return Ok(result);

                }
                if (classroom.IsPrivate == true)
                {
                    if (key.IsNullOrEmpty())
                    {
                        result.Status = 0;
                        result.Message = $"classroom is private";
                        return Ok(result);
                    }
                    else if (!KeyHash.CheckKey(key, classroom.KeyHash))
                    {
                        result.Status = 0;
                        result.Message = $"key is invalid";
                        return Ok(result);
                    }
                }
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
            catch (Exception e)
            {
                result.Message = e.Message;
                return BadRequest(result);
            }
        }


        [HttpPost]
        [HttpOptions]
        [Route("leave-classroom")]
        public async Task<ActionResult> LeaveClassroom([FromForm] string? idClassroom, [FromForm] string? idMember)
        {
            var result = new ResultStatus()
            {
                Status = -1,
                Message = "Error!"
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
                            eventMessage = _classroomStateMessage.Delete,
                            NameMember = string.Empty,
                            Avatar = string.Empty,
                            NameClassroom = classroom.Name
                        });
                    }
                    result.Status = 1;
                    result.Message = $"Leave classroom \"{classroom.Name}\" is successful";
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
