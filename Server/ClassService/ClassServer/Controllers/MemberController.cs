using Application.Models;
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
        public ActionResult UploadExercise([FromForm] UploadExerciseModel uploadExercise)
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
                    fileName = _documentFile.SaveFile("Documents", uploadExercise.FileUpload, $"Exercise{Convert.ToBase64String(id.ToByteArray()).Substring(0, 8)}{ext}");
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

        [HttpPost]
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
                var fileName = string.Empty;
                if (updateExerciseRequest.FileUpload != null)
                {
                    var ext = Path.GetExtension(updateExerciseRequest.FileUpload.FileName);
                    fileName = _documentFile.SaveFile("Documents", updateExerciseRequest.FileUpload, $"Exercise{Convert.ToBase64String(updateExerciseRequest.IdExercise.ToByteArray()).Substring(0, 8)}{ext}");
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
        public ActionResult UploadAnswer([FromForm] UploadAnswerModel uploadAnswer)
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
