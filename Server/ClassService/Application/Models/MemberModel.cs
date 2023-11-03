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
        public MemberModel(MemberClassroom classroomDetail)
        {
            this.idMember = classroomDetail.IdUser;
            this.role = classroomDetail.Role;
            this.description = classroomDetail.Description;
        }


    }
}
