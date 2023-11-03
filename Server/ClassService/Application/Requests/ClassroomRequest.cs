using Application.Models;
using Domain.Entities;
using Infrastructure;
using Microsoft.IdentityModel.Tokens;
using XAct;

namespace Application.Requests
{
    public class ClassroomRequest
    {
        public string? idClassroom { get; set; }
        public string? description { get; set; }
        public string? idUserHost { get; set; }
        public string? key { get; set; }
        public string? name { get; set; }
        public bool isPrivate { get; set; }
        public List<MemberModel>? Members { get; set; }


        //update data from "ClassroomRequest" to "Classroom"
        public void UpdateToClassroom(Classroom classroom)
        {
            if (this.isPrivate == true && this.key.IsNullOrEmpty())
            {
                classroom.KeyHash = KeyHash.Hash(this.key);
                classroom.IsPrivate = this.isPrivate;
            }
            classroom.Description = this.description;
            classroom.Name = this.name;
            if (!this.Members.IsNullOrEmpty())
            {
                foreach (var item in this.Members)
                {
                    classroom.ListUserId.Add( new MemberClassroom() 
                        { 
                            IdClass = classroom.Id,
                            IdUser = item.idMember,
                            Description = item.description,
                            Role = item.role,
                        });
                }

            }
            
        }
    }
}
