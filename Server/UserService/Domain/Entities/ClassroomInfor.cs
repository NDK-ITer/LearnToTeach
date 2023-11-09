namespace Domain.Entities
{
    public class ClassroomInfor
    {
        public string IdClassroom { get; set; }
        public string IdUser { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsHost { get; set; }
        public User User { get; set; }
    }
}
