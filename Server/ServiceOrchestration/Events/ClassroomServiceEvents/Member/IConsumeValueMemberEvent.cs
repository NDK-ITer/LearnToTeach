using Events.ClassroomServiceEvents.Models;

namespace Events.ClassroomServiceEvents.Member
{
    public interface IConsumeValueMemberEvent
    {
        public Guid idClassroom { get; }
        public List<MemberEventModel> ListMember {  get; }
    }
}
