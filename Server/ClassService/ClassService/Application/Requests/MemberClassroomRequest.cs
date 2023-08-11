using Domain.Entities;

namespace Application.Requests
{
    public class MemberClassroomRequest
    {
        public string idClassroom { get; set; }
        public string idUser { get; set; }
        public string? role { get; set; }
        public string? description { get; set; }

        public void ChangeToClassroomDetail(ClassroomDetail classroomDetail)
        {
            if (classroomDetail == null) { classroomDetail = new ClassroomDetail(); }
            if (idClassroom != null) { classroomDetail.IdClass = idClassroom; }
            if (idUser != null) { classroomDetail.IdUser = this.idUser; }
            if (role != null) { classroomDetail.Role = this.role; }
            if (!string.IsNullOrEmpty(description)) { classroomDetail.Description = this.description; }
        }
    }
}
