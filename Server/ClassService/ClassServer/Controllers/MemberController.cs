using Application.Models;
using Application.Services;
using ClassServer.FileMethods;
using ClassServer.Models;
using Domain.Entities;
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
                var createExerciseModel = new CreateExerciseModel()
                {
                    IdClassroom = uploadExercise.IdClassroom,
                    IdMember = uploadExercise.IdMember,
                    Name = uploadExercise.Name,
                    Description = uploadExercise.Description,
                    Deadline = uploadExercise.Deadline,
                };
                var exerciseResult = _unitOfWork_ClassroomService._memberService.CreateExercise(createExerciseModel);
                if (exerciseResult.Item2 == null)
                {
                    result.Status = 0;
                    result.Message = exerciseResult.Item1;
                }
                return Ok(result);
            }
            catch (Exception)
            {
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
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(result);
            }
        }
    }
}
