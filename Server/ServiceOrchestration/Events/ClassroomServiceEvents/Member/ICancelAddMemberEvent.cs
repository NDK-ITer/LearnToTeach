namespace Events.ClassroomServiceEvents.Member
{
    public interface ICancelAddMemberEvent
    {
        public Guid IdClassroom { get; set; }
        public string IdMember { get; set; }
        
    }
}
