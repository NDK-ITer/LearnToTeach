using Domain.Entities;

namespace Application.Models
{
    public class MemberModel
    {
        public string idMember { get; set; }
        public string? nameMember { get; set; }
        public string? avatar { get; set; }
        public string? linkAvatar { get; set; }
        public string? role { get; set; }
        public string? description { get; set; }

        public MemberModel(){}
        public MemberModel(MemberClassroom memberClassroom)
        {
            idMember = memberClassroom.IdUser;
            role = memberClassroom.Role;
            description = memberClassroom.Description;
            avatar = memberClassroom.Avatar;
            linkAvatar = memberClassroom.LinkAvatar;
            nameMember = memberClassroom.Name;
        }


    }
}
