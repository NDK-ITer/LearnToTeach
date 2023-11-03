using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMemberClassroomRepository : IGenericRepository<MemberClassroom>
    {
        List<MemberClassroom> GeMemberClassroomByIdUser(string idMemberClassroom);
        void UpdateMemberClassroom(MemberClassroom memberClassroom);
        bool DeleteMemberClassroom(string idMemberClassroomId, string idClassroom);
        bool DeleteRangeMemberClassroom(List<string> listIdMemberClassroom, string idClassroom);
    }
}
