using Events.ClassroomServiceEvents.Models;

namespace Events.ClassroomServiceEvents.Member.AddMember
{
    public interface IAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public string NameClassroom { get; }
        public List<MemberEventModel> ListMember { get; }
    }
}
