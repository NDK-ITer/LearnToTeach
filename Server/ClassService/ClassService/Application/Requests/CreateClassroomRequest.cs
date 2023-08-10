namespace Application.Requests
{
    public class CreateClassroomRequest
    {
        public string idUser { get; set; }
        public string nameClassroom { get; set; }
        public bool isPrivate { get; set; }
        public string? key { get; set; }
        public string? Description { get; set; }
        public IEnumerable<string>? idMembers { get; set; }
    }
}
