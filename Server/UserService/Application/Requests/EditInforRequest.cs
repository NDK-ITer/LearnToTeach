using Microsoft.AspNetCore.Http;

namespace Application.Requests
{
    public class EditInforRequest
    {
        public string IdUser { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
