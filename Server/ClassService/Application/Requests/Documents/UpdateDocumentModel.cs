using Microsoft.AspNetCore.Http;

namespace Application.Requests.Documents
{
    public class UpdateDocumentModel
    {
        public string IdClassroom { get; set; }
        public string IdMember { get; set; }
        public string NameFile { get; set; }
        public string Decription { get; set; }
        public IFormFile FileUpload { get; set; }
    }
}
