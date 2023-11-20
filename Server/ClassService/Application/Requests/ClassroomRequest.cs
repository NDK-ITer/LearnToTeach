using Domain.Entities;
using Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using XAct;

namespace Application.Requests
{
    public class ClassroomRequest
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
