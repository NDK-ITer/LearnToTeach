using Domain.Entities;

namespace Application.Models
{
    public class ClassroomModel
    {
        public string? idClassroom { get; set; }
        public string? description { get; set; }
        public string? idUserHost { get; set; }
        public string? key { get; set; }
        public string? name { get; set; }
        public bool isPrivate { get; set; }
        public List<MemberModel>? Members { get; set; }
        public ClassroomModel(Classroom classroom)
        {
            if (classroom != null)
            {
                this.idClassroom = classroom.Id;
                this.name = classroom.Name;
                this.description = classroom.Description;
                Members = new List<MemberModel>();
                foreach (var item in classroom.ListUserId)
                {
                    Members.Add(new MemberModel(item));
                }
            }
        }
    }
}
