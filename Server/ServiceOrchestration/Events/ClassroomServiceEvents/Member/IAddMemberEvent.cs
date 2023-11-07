using Events.ClassroomServiceEvents.Models;

namespace Events.ClassroomServiceEvents.Member
{
    public interface IAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public List<MemberEventModel> ListMember { get; }
    }
}
