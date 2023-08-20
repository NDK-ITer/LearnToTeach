using Application.Models;
using Domain.Entities;
using Infrastructure;
using Microsoft.IdentityModel.Tokens;
using XAct;

namespace Application.Requests
{
    public class ClassroomRequest
    {
        public ClassroomModel classroomModel { get; set; }
        

        //update data from "ClassroomRequest" to "Classroom"
        public void UpdateToClassroom(Classroom classroom)
        {
            if (this.classroomModel.isPrivate == true && this.classroomModel.key.IsNullOrEmpty())
            {
                classroom.KeyHash = KeyHash.Hash(this.classroomModel.key);
                classroom.IsPrivate = this.classroomModel.isPrivate;
            }
            classroom.Description = this.classroomModel.description;
            classroom.Name = this.classroomModel.name;
            if (!this.classroomModel.Members.IsNullOrEmpty())
            {
                foreach (var item in this.classroomModel.Members)
                {
                    classroom.ListUserId.Add( new ClassroomDetail() 
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
