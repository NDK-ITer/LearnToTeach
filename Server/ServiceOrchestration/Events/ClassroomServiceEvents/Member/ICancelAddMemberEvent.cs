using Events.ClassroomServiceEvents.Models;

namespace Events.ClassroomServiceEvents.Member
{
    public interface ICancelAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public List<MemberEventModel> ListMember { get; }
        
    }
}
