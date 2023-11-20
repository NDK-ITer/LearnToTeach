using Application.Services;
using ClassServer.FileMethods;
using ClassServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork_ClassroomService _unitOfWork_ClassroomService;
        private readonly DocumentFileMethod _documentFile;

        public MemberController(IUnitOfWork_ClassroomService unitOfWork_ClassroomService,
            DocumentFileMethod documentFile)
        {
            _unitOfWork_ClassroomService = unitOfWork_ClassroomService;
            _documentFile = documentFile;
        }
        /// <summary>
        /// be testing
        /// </summary>
        /// <param name="uploadAnswer"></param>
        /// <returns></returns>
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
