using Microsoft.AspNetCore.Http;

namespace Application.Models
{
    public class AddClassroomModel
    {
        public string? idClassroom { get; set; }
        public string? description { get; set; }
        public string? idUserHost { get; set; }
        public string? key { get; set; }
        public string? name { get; set; }
        public bool isPrivate { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
