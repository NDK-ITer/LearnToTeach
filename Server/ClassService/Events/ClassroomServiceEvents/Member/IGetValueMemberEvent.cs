using Events.ClassroomServiceEvents.Models;

namespace Events.ClassroomServiceEvents.Member
{
    public interface IGetValueMemberEvent
    {
        public Guid IdClassroom { get; }
        public string NameClassroom { get; }
        public List<string> ListIdMember { get; }
        public string eventMessage { get; }
    }
}
