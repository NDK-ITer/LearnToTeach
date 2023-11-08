using Events.ClassroomServiceEvents.Models;

namespace Events.ClassroomServiceEvents.Member.AddMember
{
    public interface ICancelAddMemberEvent
    {
        public Guid IdClassroom { get; }
        public string NameClassroom { get; }
        public List<MemberEventModel> ListMember { get; }

    }
}
