using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Events.ClassroomServiceEvents.Classroom
{
    public interface IConsumeValueClassroomEvent
    {
        public Guid idClassroom { get;}
        public string? description { get; }
        public string? idUserHost { get; }
        public string? name { get; }
        public bool isPrivate { get; }
        public string eventMessage { get; }
    }
}
