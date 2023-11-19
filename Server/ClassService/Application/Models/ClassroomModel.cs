using Domain.Entities;
using System.Data;

namespace Application.Models
{
    public class ClassroomModel
    {
        public string? idClassroom { get; set; }
        public string? avatarClassroom { get; set; }
        public string? description { get; set; }
        public string? key { get; set; }
        public string? name { get; set; }
        public bool isPrivate { get; set; }
        public List<MemberModel>? Members { get; set; }
        public ClassroomModel(Classroom classroom)
        {
            if (classroom != null)
            {
                idClassroom = classroom.Id;
                avatarClassroom = $"{classroom.LinkAvatar}/{classroom.Avatar}";
                name = classroom.Name;
                description = classroom.Description;
                Members = new List<MemberModel>();
                foreach (var item in classroom.ListMember)
                {
                    Members.Add(new MemberModel(item, classroom.Id));
                }
            }
        }
    }
}
