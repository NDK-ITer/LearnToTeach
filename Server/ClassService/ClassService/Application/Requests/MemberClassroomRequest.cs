using Application.Models;
using Domain.Entities;

namespace Application.Requests
{
    public class MemberClassroomRequest
    {
        public string idClassroom { get; set; }
        public List<MemberModel> idMembers { get; set; }

        public void ChangeToClassroomDetail(List<ClassroomDetail> classroomDetails)
        {
            if (classroomDetails == null) { classroomDetails = new List<ClassroomDetail>(); }
            foreach (var item in idMembers)
            {
                var classroomDetail = new ClassroomDetail() 
                {
                    IdClass = idClassroom,
                    IdUser = item.idMember,
                    Description = item.description,
                    Role = item.role,
                };
                classroomDetails.Add(classroomDetail);
            }
        }
    }
}
