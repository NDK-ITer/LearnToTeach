using Domain.Entities;

namespace Application.Models.ModelsOfMember
{
    public class MemberModel
    {
        public string idMember { get; set; }
        public string? nameMember { get; set; }
        public string? avatar { get; set; }
        public string? role { get; set; }
        public string? description { get; set; }
        public MemberModel() { }
        public MemberModel(Member memberClassroom, string idClassroom)
        {
            idMember = memberClassroom.IdMember;
            avatar = $"{memberClassroom.LinkAvatar}/{memberClassroom.Avatar}";
            nameMember = memberClassroom.Name;
            role = memberClassroom.ListMemberClassroom.FirstOrDefault(p => p.IdClass == idClassroom).Role;
        }


    }
}
