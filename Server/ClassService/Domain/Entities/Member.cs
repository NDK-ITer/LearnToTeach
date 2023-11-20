namespace Domain.Entities
{
    public class Member
    {
        public string IdMember { get; set; }
        public string? Name { get; set; }
        public string? LinkAvatar { get; set; }
        public string? Avatar { get; set; }
        public List<Classroom>? ListClassroom { get; set; }
        public List<MemberClassroom>? ListMemberClassroom { get; set; }
        public List<Answer>? ListAnswer { get; set; }
        public List<Exercise>? ListExercise { get; set; }
    }
}
