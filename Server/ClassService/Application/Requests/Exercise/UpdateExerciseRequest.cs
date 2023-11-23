using Microsoft.AspNetCore.Http;

namespace Application.Requests.Exercise
{
    public class UpdateExerciseRequest
    {
        public string IdExercise { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? FileUpload { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
