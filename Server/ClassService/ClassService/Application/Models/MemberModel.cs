using Domain.Entities;

namespace Application.Models
{
    public class MemberModel
    {
        public string idMember { get; set; }
        public string? role { get; set; }
        public string? description { get; set; }
    }
}
