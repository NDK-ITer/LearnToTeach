using Application.Models.ModelOfLearningDocument;
using Application.Models.ModelOfNotifyClassroom;
using Application.Models.ModelsOfAnswer;
using Application.Models.ModelsOfExercise;
using Application.Requests.Answer;
using Application.Requests.Documents;
using Application.Requests.Exercise;
using Application.Requests.Notify;
using Application.Services;
using ClassServer.FileMethods;
using ClassServer.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using XAct;
using ResultStatus = ClassServer.Models.ResultStatus;

namespace ClassServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork_ClassroomService _unitOfWork_ClassroomService;
        private readonly IOptions<Address> _address;
        private readonly DocumentFileMethod _documentFile;

        public MemberController(IUnitOfWork_ClassroomService unitOfWork_ClassroomService,
            DocumentFileMethod documentFile,
            IOptions<Address> address)
        {
            _unitOfWork_ClassroomService = unitOfWork_ClassroomService;
            _documentFile = documentFile;
            _address = address;
        }

        [HttpPost]
        [HttpOptions]
        [Route("upload-exercise")]
        public ActionResult UploadExercise([FromForm] UploadExerciseRequest uploadExercise)
        {
            var result = new ResultStatus()
            {
                Status = -1,
                Message = "Error!"
            };
            try
            {
                var check = _unitOfWork_ClassroomService._memberService.IsHost(uploadExercise.IdMember, uploadExercise.IdClassroom);
                if (!check.Item1)
                {
                    result.Status = 0;
                    result.Message = check.Item2;
                    return Ok(result);
                }
                var id = Guid.NewGuid().ToString();
                var fileName = string.Empty;
                if (uploadExercise.FileUpload != null)
                {
                    var ext = Path.GetExtension(uploadExercise.FileUpload.FileName);
                    fileName = _documentFile.SaveFile("Documents", uploadExercise.FileUpload, $"Exercise{Convert.ToBase64String(id.ToByteArray()).Substring(0, 10)}{ext}");
                }
                if (fileName != null)
                {
                    var createExerciseModel = new CreateExerciseModel()
                    {
                        IdExercise = id,
                        IdClassroom = uploadExercise.IdClassroom,
                        IdMember = uploadExercise.IdMember,
                        Name = uploadExercise.Name,
                        Description = uploadExercise.Description,
                        LinkFile = _address.Value.ThisServiceAddress,
                        FileName = fileName,
                        Deadline = uploadExercise.Deadline,
                    };
                    var exerciseResult = _unitOfWork_ClassroomService._memberService.CreateExercise(createExerciseModel);
                    if (exerciseResult.Item2 != null)
                    {
                        result.Status = 1;
                        result.Message = exerciseResult.Item1;
                    }
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                return BadRequest(result);
            }
        }

        [HttpPut]
        [HttpOptions]
        [Route("update-exercise")]
        public ActionResult UpdateExercise([FromForm] UpdateExerciseRequest updateExerciseRequest)
        {
            var result = new ResultStatus()
            {
                Status = -1,
                Message = "Error!"
            };
            try
            {
                var checkHost = _unitOfWork_ClassroomService._memberService.IsHost(updateExerciseRequest.IdMember, updateExerciseRequest.IdClassroom);
                if (!checkHost.Item1)
                {
                    result.Status = 0;
                    result.Message = checkHost.Item2;
                    return Ok(result);
                }
                var fileName = string.Empty;
                if (updateExerciseRequest.FileUpload != null)
                {
                    var ext = Path.GetExtension(updateExerciseRequest.FileUpload.FileName);
                    fileName = _documentFile.SaveFile("Documents", updateExerciseRequest.FileUpload, $"Exercise{Convert.ToBase64String(updateExerciseRequest.IdExercise.ToByteArray()).Substring(0, 10)}{ext}");
                }
                if (fileName != null)
                {
                    var exerciseUpdate = new UpdateExerciseModel()
                    {
                        IdExercise = updateExerciseRequest.IdExercise,
                        Name = updateExerciseRequest.Name,
                        Description = updateExerciseRequest.Description,
                        Deadline = updateExerciseRequest.Deadline,
                    };
                    var check = _unitOfWork_ClassroomService._exerciseService.UpdateExercise(exerciseUpdate);
                    if (check != null)
                    {
                        if (check.Item2 != null)
                        {
                            result.Status = 1;
                        }
                        result.Status = 0;
                        result.Message = check.Item1;
                    }

                }
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
        [Route("upload-answer")]
        public ActionResult UploadAnswer([FromForm] UploadAnswerRequest uploadAnswer)
        {
            var result = new ResultStatus()
            {
                Status = -1,
                Message = "Error!"
            };
            try
            {
                var checkMemberInClassroom = _unitOfWork_ClassroomService._classroomService.MemberIsInClassroom(uploadAnswer.IdClassroom, uploadAnswer.IdMember);
                var exercise = _unitOfWork_ClassroomService._exerciseService.GetExerciseById(uploadAnswer.IdExercise);
                if (exercise == null)
                {
                    result.Status = 0;
                    result.Message = "Not found this exercise in classroom";
                    return Ok(result);
                }
                if (exercise.ListAnswer.FirstOrDefault(p => p.IdMember == uploadAnswer.IdMember) != null)
                {
                    result.Status = 0;
                    result.Message = "this answer have been available";
                    return Ok(result);
                }
                if (!checkMemberInClassroom)
                {
                    result.Status = 0;
                    result.Message = "You are not in this classroom";
                    return Ok(result);
                }
                if (exercise.DeadLine < DateTime.Now)
                {
                    result.Status = 0;
                    result.Message = "You are past the deadline of this exercise";
                    return Ok(result);
                }
                var id = Guid.NewGuid().ToString();
                var fileName = string.Empty;
                if (uploadAnswer.FileUpload != null)
                {
                    var ext = Path.GetExtension(uploadAnswer.FileUpload.FileName);
                    fileName = _documentFile.SaveFile("Documents", uploadAnswer.FileUpload, $"Answer{Convert.ToBase64String($"{uploadAnswer.IdExercise}{uploadAnswer.IdMember}".ToByteArray()).Substring(0, 20)}{ext}");
                }
                if (fileName != null)
                {
                    var createAnswerModel = new CreateAnswerModel()
                    {
                        IdExercise = uploadAnswer.IdExercise,
                        IdMember = uploadAnswer.IdMember,
                        Content = uploadAnswer.Content,
                        LinkFile = _address.Value.ThisServiceAddress,
                        FileName = fileName
                    };
                    var check = _unitOfWork_ClassroomService._answerService.CreateAnswer(createAnswerModel);
                    if (check.Item2 != null)
                    {
                        result.Status = 1;
                        result.Message = check.Item1;
                    }
                }
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
        [Route("set-point-answer")]
        public ActionResult UploadAnswer([FromForm] SetPointModel setPoint)
        {
            var result = new ResultStatus()
            {
                Status = 0,
                Message = "Error!"
            };
            try
            {
                var check = _unitOfWork_ClassroomService._memberService.IsHost(setPoint.IdUserHost, setPoint.IdClassroom);
                if (!check.Item1)
                {
                    result.Message = check.Item2;
                    return Ok(result);
                }
                var id = Guid.NewGuid().ToString();
                var fileName = string.Empty;

                var checkUpdate = _unitOfWork_ClassroomService._answerService.UpdateAnswer(setPoint.IdExercise, setPoint.IdMember,setPoint.Point);
                if (checkUpdate.Item2 != null)
                {
                    result.Status = 1;
                }
                result.Message = checkUpdate.Item1;
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                return BadRequest(result);
            }
        }

        [HttpPut]
        [HttpOptions]
        [Route("update-answer")]
        public ActionResult UpdateAnswer([FromForm] UpdateAnswerRequest updateAnswer)
        {
            var result = new ResultStatus()
            {
                Status = -1,
                Message = "Error!"
            };
            try
            {
                var checkMemberInClassroom = _unitOfWork_ClassroomService._classroomService.MemberIsInClassroom(updateAnswer.IdClassroom, updateAnswer.IdMember);
                var exercise = _unitOfWork_ClassroomService._exerciseService.GetExerciseById(updateAnswer.IdExercise);
                if (exercise == null)
                {
                    result.Status = 0;
                    result.Message = "Not found this exercise in classroom";
                    return Ok(result);
                }
                if (!checkMemberInClassroom)
                {
                    result.Status = 0;
                    result.Message = "You are not in this classroom";
                    return Ok(result);
                }
                if (exercise.DeadLine < DateTime.Now)
                {
                    result.Status = 0;
                    result.Message = "You are past the deadline of this exercise";
                    return Ok(result);
                }
                var answer = _unitOfWork_ClassroomService._answerService.GetAnswerById(updateAnswer.IdExercise, updateAnswer.IdMember);
                if (answer.Item2 == null)
                {
                    result.Status = 0;
                    result.Message = "This answer is not exist";
                    return Ok(result);
                }
                var fileName = string.Empty;
                if (updateAnswer.FileUpload != null)
                {
                    var ext = Path.GetExtension(updateAnswer.FileUpload.FileName);
                    fileName = _documentFile.SaveFile("Documents", updateAnswer.FileUpload, $"Answer{Convert.ToBase64String($"{updateAnswer.IdExercise}{updateAnswer.IdMember}".ToByteArray()).Substring(0, 20)}{ext}");
                }
                var updateAnswerModel = new UpdateAnswerModel()
                {
                    IdExercise = updateAnswer.IdExercise,
                    IdMember = updateAnswer.IdMember,
                    Content = updateAnswer.Content,
                    LinkFile = _address.Value.ThisServiceAddress,
                    FileName = fileName
                };
                var check = _unitOfWork_ClassroomService._answerService.UpdateAnswer(updateAnswerModel);
                if (check.Item2 != null)
                {
                    result.Status = 1;
                    result.Message = check.Item1;
                }
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
        [Route("upload-doc")]
        public ActionResult UploadDocument([FromForm] UploadDocumentModel upload)
        {
            var result = new ResultStatus()
            {
                Status = 0,
                Message = ""
            };
            try
            {
                if (upload != null)
                {
                    var check = _unitOfWork_ClassroomService._memberService.IsHost(upload.IdMember, upload.IdClassroom);
                    if (!check.Item1)
                    {
                        result.Message = check.Item2;
                        return Ok(result);
                    }
                    var id = Guid.NewGuid().ToString();
                    var fileName = string.Empty;
                    if (upload.FileUpload != null)
                    {
                        var ext = Path.GetExtension(upload.FileUpload.FileName);
                        fileName = _documentFile.SaveFile("Documents", upload.FileUpload, $"Doc{Convert.ToBase64String(id.ToByteArray()).Substring(0, 10)}{ext}");
                    }
                    var addDoc = new AddLearningDocumentModel()
                    {
                        IdClassroom = upload.IdClassroom,
                        Description = upload.Decription,
                        NameFile = fileName,
                        LinkFile = _address.Value.ThisServiceAddress
                    };
                    _unitOfWork_ClassroomService._learningDocumentService.AddLearningDocument(addDoc);
                }
                result.Status = 1;
                result.Message = "up load successfull";
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Status = -1;
                result.Message = e.Message;
                return Ok(result);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("update-doc")]
        public ActionResult UpdateDocument([FromForm] UpdateDocumentModel upload)
        {
            var result = new ResultStatus()
            {
                Status = 0,
                Message = ""
            };
            try
            {
                if (upload != null)
                {
                    var check = _unitOfWork_ClassroomService._memberService.IsHost(upload.IdMember, upload.IdClassroom);
                    if (!check.Item1)
                    {
                        result.Message = check.Item2;
                        return Ok(result);
                    }
                    var fileName = string.Empty;
                    if (upload.FileUpload != null)
                    {
                        var ext = Path.GetExtension(upload.FileUpload.FileName);
                        fileName = _documentFile.SaveFile("Documents", upload.FileUpload, $"{upload.NameFile}{ext}");
                    }
                    var udateDoc = new UpdateLearningDocumentModel()
                    {
                        Description = upload.Decription,
                        NameFile = upload.NameFile,
                    };
                    _unitOfWork_ClassroomService._learningDocumentService.UpdateLearningDocument(udateDoc);
                }
                result.Status = 0;
                result.Message = "parameter is null";
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Status = -1;
                result.Message = e.Message;
                return Ok(result);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("upload-notify")]
        public ActionResult UploadNotify([FromForm] UploadNotifyRequest upload)
        {
            var result = new ResultStatus()
            {
                Status = 0,
                Message = ""
            };
            try
            {
                if (upload != null)
                {
                    var check = _unitOfWork_ClassroomService._memberService.IsHost(upload.IdMember, upload.IdClassroom);
                    if (!check.Item1)
                    {
                        result.Message = check.Item2;
                        return Ok(result);
                    }
                    var addNotify = new AddNotifyClassroomModel()
                    {
                        IdClassroom = upload.IdClassroom,
                        NameNotify = upload.NameNotify,
                        Description = upload.Decription
                    };
                    var checkAdd = _unitOfWork_ClassroomService._notifyClassroomService.Add(addNotify);
                    if (checkAdd.Item2 != null)
                    {
                        result.Status = 1;
                    }
                    result.Message = checkAdd.Item1;
                    return Ok(result);
                }
                
                result.Status = 0;
                result.Message = "parameter is null";
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Status = -1;
                result.Message = e.Message;
                return Ok(result);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("update-notify")]
        public ActionResult UpdateNotify([FromForm] UpdateNotifyRequest upload)
        {
            var result = new ResultStatus()
            {
                Status = 0,
                Message = ""
            };
            try
            {
                if (upload != null)
                {
                    var check = _unitOfWork_ClassroomService._memberService.IsHost(upload.IdMember, upload.IdClassroom);
                    if (!check.Item1)
                    {
                        result.Message = check.Item2;
                        return Ok(result);
                    }
                    var updateNotify = new UpdateNotifyClassroomModel()
                    {
                        //IdClassroom = upload.IdClassroom,
                        IdNotify = upload.IdNotify,
                        NameNotify = upload.NameNotify,
                        Description = upload.Description,
                    };
                    var checkAdd = _unitOfWork_ClassroomService._notifyClassroomService.Update(updateNotify);
                    if (checkAdd.Item2 != null)
                    {
                        result.Status = 1;
                    }
                    result.Message = checkAdd.Item1;
                    return Ok(result);
                }
                result.Status = 0;
                result.Message = "parameter is null";
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Status = -1;
                result.Message = e.Message;
                return Ok(result);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("delete-notify")]
        public ActionResult DeleteNotify([FromForm] UpdateNotifyRequest upload)
        {
            var result = new ResultStatus()
            {
                Status = 0,
                Message = ""
            };
            try
            {
                if (upload != null)
                {
                    var check = _unitOfWork_ClassroomService._memberService.IsHost(upload.IdMember, upload.IdClassroom);
                    if (!check.Item1)
                    {
                        result.Message = check.Item2;
                        return Ok(result);
                    }
                    var checkAdd = _unitOfWork_ClassroomService._notifyClassroomService.Delete(upload.IdNotify);
                    if (checkAdd.Item1 == false)
                    {
                        result.Status = 1;
                    }
                    result.Message = checkAdd.Item2;
                    return Ok(result);
                }
                result.Status = 0;
                result.Message = "parameter is null";
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Status = -1;
                result.Message = e.Message;
                return Ok(result);
            }
        }
    }
}
