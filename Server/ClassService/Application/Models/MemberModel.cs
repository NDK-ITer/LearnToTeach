using Domain.Entities;

namespace Application.Models
{
    public class MemberModel
    {
        public string idMember { get; set; }
        public string? nameMember { get; set; }
        public string? avatar { get; set; }
        public string? role { get; set; }
        public string? description { get; set; }

        public MemberModel(){}
        public MemberModel(MemberClassroom memberClassroom)
        {
            this.idMember = memberClassroom.IdUser;
            this.role = memberClassroom.Role;
            this.description = memberClassroom.Description;
            this.avatar = memberClassroom.Avatar;
            this.nameMember = memberClassroom.Name;
        }


    }
}
