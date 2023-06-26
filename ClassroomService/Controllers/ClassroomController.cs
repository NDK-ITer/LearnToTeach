using ClassroomService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        List<ClassroomModel> classrooms;
        public ClassroomController()
        {
            classrooms = new List<ClassroomModel>()
            {
                new ClassroomModel() {Id = Guid.NewGuid(), Name = "Class-1", Description = "1"},
                new ClassroomModel() {Id = Guid.NewGuid(), Name = "Class-2", Description = "2"},
                new ClassroomModel() {Id = Guid.NewGuid(), Name = "Class-3", Description = "3"},
                new ClassroomModel() {Id = Guid.NewGuid(), Name = "Class-4", Description = "4"},
            };
        }

        [Route("All")]
        [HttpGet]
        public ActionResult<List<ClassroomModel>> GetAllClassroom()
        {
            return classrooms.ToList();
        }
    }
}
