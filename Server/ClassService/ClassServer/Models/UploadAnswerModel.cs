namespace ClassServer.Models
{
    public class UploadAnswerModel
    {
        public string IdClassroom { get; set; }
        public string IdMember { get; set; }
        public string IdExercise { get; set; }
        public string Content { get; set; }
        public IFormFile FileUpload { get; set; }
    }
}
