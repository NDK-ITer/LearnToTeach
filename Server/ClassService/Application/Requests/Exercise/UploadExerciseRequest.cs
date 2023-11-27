using Microsoft.AspNetCore.Http;

namespace Application.Requests.Exercise
{
    public class UploadExerciseRequest
    {
        public string IdClassroom { get; set; }
        public string IdMember { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
        public IFormFile? FileUpload { get; set; }
    }
}
