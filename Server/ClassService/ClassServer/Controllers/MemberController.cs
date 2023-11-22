using Application.Models;
using Application.Services;
using ClassServer.FileMethods;
using ClassServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
                if (!_unitOfWork_ClassroomService._memberService.IsHost(uploadExercise.IdMember, uploadExercise.IdClassroom))
                {
                    result.Status = 0;
                    result.Message = "Member isn't \"Host\"";
                    return Ok(result);
                }
                var id = Guid.NewGuid().ToString();
                var fileName = string.Empty;
                if (uploadExercise.FileUpload != null)
                {
                    var ext = Path.GetExtension(uploadExercise.FileUpload.FileName);
                    fileName = _documentFile.SaveFile("Documents/Exercises", uploadExercise.FileUpload, $"{id}{ext}");
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
                        result.Status = 0;
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
                //var exercise = _unitOfWork_ClassroomService
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(result);
            }
        }
    }
}
