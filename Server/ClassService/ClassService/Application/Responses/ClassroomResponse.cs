using Application.Models;
using Domain.Entities;

namespace Application.Responses
{
    public class ClassroomResponse
    {
        public string idClassroom { get; set; }
        public string name { get; set;}
        public string description { get; set;}
        public List<MemberModel>? listMember { get; set; }

        public ClassroomResponse(){}
        public ClassroomResponse(Classroom classroom)
        {
            if (classroom != null)
            {
                this.idClassroom = classroom.Id;
                this.name = classroom.Name;
                this.description = classroom.Description;
                listMember = new List<MemberModel>();
                foreach (var item in classroom.ListUserId)
                {
                    listMember.Add(new MemberModel(item));
                }
            }
        }
    }
}
