using Microsoft.AspNetCore.Http;

namespace ClassServer.Models
{
    public class UploadDocumentModel
    {
        public string IdClassroom { get; set; }
        public string IdMember { get; set; }
        public string? Decription { get; set; }
        public IFormFile? FileUpload { get; set; }
    }
}
