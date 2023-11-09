using Events.ClassroomServiceEvents.Models;

namespace Events.ClassroomServiceEvents.Member.AddMember
{
    public interface IAddMemberIsValidEvent
    {
        public Guid IdClassroom { get; }
        public string IdMember { get; }
        public string NameClassroom { get; }
        public string NameMember { get; }
        public string Avatar { get; }
    }
}
