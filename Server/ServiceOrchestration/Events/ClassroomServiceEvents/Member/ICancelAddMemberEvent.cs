namespace Events.ClassroomServiceEvents.Member
{
    public interface ICancelAddMemberEvent
    {
        public Guid idClassroom { get; set; }
        //public string? description { get; set; }
        //public string? idUserHost { get; set; }
        //public string? key { get; set; }
        //public string? name { get; set; }
        //public bool isPrivate { get; set; }
        public string? IdMember { get; set; }
    }
}
