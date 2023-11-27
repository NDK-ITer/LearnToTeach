namespace Domain.Entities
{
    public class Classroom
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string? KeyHash { get; set; }
        public string? LinkAvatar { get; set; }
        public string? Avatar { get; set; }
        public bool IsPrivate { get; set; }
        public List<Member>? ListMember { get; set; }
        public List<MemberClassroom>? ListMemberClassroom { get; set; }
        public List<Exercise>? ListExercise { get; set; }
        public List<LearningDocument>? ListDocument { get; set; }
        public List<NotifyClassroom>? ListNotifies { get; set; }

    }
}
