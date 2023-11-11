using Domain.Entities;
using System.Data;

namespace Application.Models
{
    public class ClassroomModel
    {
        public string? idClassroom { get; set; }
        public string? description { get; set; }
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
                Members = new List<MemberModel>()
                {
                    new MemberModel()
                    {
                        idMember = classroom.IdUserHost,
                        nameMember = classroom.NameUserHost,
                        avatar = classroom.AvatarUserHost,
                        role = "Host",
                        description = "All in this classroom",
                    }
                };
                foreach (var item in classroom.ListUserId)
                {
                    Members.Add(new MemberModel(item));
                }
            }
        }
    }
}
